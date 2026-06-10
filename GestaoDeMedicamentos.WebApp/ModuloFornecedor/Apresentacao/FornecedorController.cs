using AutoMapper;
using FluentResults;
using GestaoDeMedicamentos.WebApp.Compartilhado.Apresentacao.Extensions;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Aplicacao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace GestaoDeMedicamentos.WebApp.ModuloFornecedor.Apresentacao;

public class FornecedorController : Controller
{
    public readonly ServicoFornecedor servicoFornecedor;
    public readonly IMapper mapper;
    public FornecedorController(ServicoFornecedor servicoFornecedor, IMapper mapper)
    {
        this.servicoFornecedor = servicoFornecedor;
        this.mapper = mapper;
    }

    public ActionResult Listar()
    {
        List<ListarFornecedorDTOS> fornecedorDTOs = servicoFornecedor.SelecionarTodos();
        List<ListarFornecedorViewModel> fornecedorVm = mapper.Map<List<ListarFornecedorViewModel>>(fornecedorDTOs);

        return View(fornecedorVm);
    }
    [HttpGet]
    public ActionResult Cadastrar()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Cadastrar(CadastrarFornecedorViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        CadastrarFornecedorDTOs dtos = new(vm.Nome, vm.Telefone, vm.Cnpj);

        Result resultado = servicoFornecedor.Cadastrar(dtos);

        //Aqui tem que ver dps pq ele não envia as mensagens de erros da ValidarEntidade();
        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }
    [HttpGet]
    public ActionResult Excluir(string Id)
    {
        Result<DetalhesFornecedorDto> resultado = servicoFornecedor.SelecionarPorId(Id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        ExcluirFornecedorViewModel vm = mapper.Map<ExcluirFornecedorViewModel>(resultado.Value);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirFornecedorViewModel vm)
    {
        Result resultado = servicoFornecedor.Excluir(vm.Id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        return RedirectToAction(nameof(Listar));
    }
    [HttpGet]
    public ActionResult Editar(string id)
    {
        Result<DetalhesFornecedorDto> resultado = servicoFornecedor.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        EditarFornecedorViewModel vm = mapper.Map<EditarFornecedorViewModel>(resultado.Value);

        return View(vm);
    }
    [HttpPost]
    public ActionResult Editar(EditarFornecedorViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        EditarFornecedorDTOs dto = new(vm.Id, vm.Nome, vm.Telefone, vm.Cnpj);

        Result resultado = servicoFornecedor.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(vm);
        }
        return RedirectToAction(nameof(Listar));
    }
}
