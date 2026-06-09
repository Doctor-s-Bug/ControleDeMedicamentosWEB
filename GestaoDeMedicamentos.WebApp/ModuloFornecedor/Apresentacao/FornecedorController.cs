using AutoMapper;
using FluentResults;
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

        if (resultado.IsFailed)
        {
            foreach (var erro in resultado.Errors)
            {
                string campo = erro.Metadata["Campo"]?.ToString() ?? "";

                ModelState.AddModelError(campo, erro.Message);
            }

            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }
}
