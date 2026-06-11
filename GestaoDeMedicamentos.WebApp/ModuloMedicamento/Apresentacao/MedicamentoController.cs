using AutoMapper;
using FluentResults;
using GestaoDeMedicamentos.WebApp.Compartilhado.Apresentacao.Extensions;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Apresentacao;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Aplicacao;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeMedicamentos.WebApp.ModuloMedicamento.Apresentacao;

public class MedicamentoController : Controller
{
    private readonly ServicoMedicamento servicoMedicamento;
    private readonly ServicoFornecedor servicoFornecedor;
    private readonly IMapper mapper;

    public MedicamentoController(ServicoMedicamento servicoMedicamento, IMapper mapper, ServicoFornecedor servicoFornecedor)
    {
        this.servicoMedicamento = servicoMedicamento;
        this.servicoFornecedor = servicoFornecedor;
        this.mapper = mapper;
    }

    public ActionResult Listar()
    {
        List<ListarMedicamentoDto> dtos = servicoMedicamento.SelecionarTodos();

        List<ListarMedicamentoViewModel> vms = mapper.Map<List<ListarMedicamentoViewModel>>(dtos);

        return View(vms);
    }
    public ActionResult Cadastrar()
    {
        List<ListarFornecedorDTOS> dtosFornecedor = servicoFornecedor.SelecionarTodos();

        ViewBag.Fornecedores = mapper.Map<List<ListarFornecedorViewModel>>(dtosFornecedor);

        return View();
    }
    [HttpPost]
    public ActionResult Cadastrar(CadastrarMedicamentoViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            //carrega novamente a lista de fornecedores pra n estourar exceção 
            List<ListarFornecedorDTOS> dtosFornecedor = servicoFornecedor.SelecionarTodos();
            ViewBag.Fornecedores = mapper.Map<List<ListarFornecedorViewModel>>(dtosFornecedor);

            RedirectToAction(nameof(Cadastrar));
        }

        CadastrarMedicamentoDto dto = new(vm.Nome, vm.Descricao, vm.QuantidadeEstoque, vm.Fornecedor);

        Result<CadastrarMedicamentoDto> resultado = servicoMedicamento.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(vm);
        }
        return RedirectToAction(nameof(Listar));
    }
    public ActionResult Excluir(string id)
    {
        Result<DetalhesMedicamentoDto> dto = servicoMedicamento.SelecionarPorId(id);

        if (dto.IsFailed)
        {
            TempData.AddErrorMessage(dto);
            return RedirectToAction(nameof(Listar));
        }

        ExcluirMedicamentoViewModel vm = mapper.Map<ExcluirMedicamentoViewModel>(dto.Value);

        return View(vm);
    }
    [HttpPost]
    public ActionResult Excluir(ExcluirMedicamentoViewModel vm)
    {
        ExcluirMedicamentoDto dto = new(vm.Id, vm.Nome, vm.Descricao, vm.QuantidadeEstoque, vm.Fornecedor);

        Result resultado = servicoMedicamento.Excluir(dto);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        return RedirectToAction(nameof(Listar));
    }
}
