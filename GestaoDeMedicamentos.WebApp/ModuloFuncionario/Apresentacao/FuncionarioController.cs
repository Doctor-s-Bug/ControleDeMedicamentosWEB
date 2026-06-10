using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeMedicamentos.WebApp.ModuloFuncionario.Apresentacao;

public class FuncionarioController : Controller
{
    private readonly IRepositorioFuncionario repositorioFuncionario;

    public FuncionarioController(IRepositorioFuncionario repositorioFuncionario)
    {
        this.repositorioFuncionario = repositorioFuncionario;
    }

    public ActionResult Listar()
    {
        List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();

        List<ListarFuncionarioViewModel> listarVm = new();

        foreach (Funcionario f in funcionarios)
        {
            ListarFuncionarioViewModel vm = new(f.Id, f.Nome, f.Telefone, f.Cpf);

            listarVm.Add(vm);
        }

        return View(listarVm);
    }

    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]

    public ActionResult Cadastrar(CadastrarFuncionarioViewModel vm)
    {
        Funcionario novoFuncionario = new(vm.Nome, vm.Telefone, vm.Cpf);
        repositorioFuncionario.Cadastrar(novoFuncionario);
        return RedirectToAction(nameof(Listar));
    }

    public ActionResult Excluir(string Id)
    {
        Funcionario? novoFuncionario = repositorioFuncionario.SelecionarPorId(Id);
        ExcluirFuncionarioViewModel vm = new(novoFuncionario.Id, novoFuncionario.Nome, novoFuncionario.Cpf, novoFuncionario.Telefone);
        return View(vm);
    }

    [HttpPost]

    public ActionResult Excluir(ExcluirFuncionarioViewModel vm)
    {
        Funcionario? funcionarioExcluir = repositorioFuncionario.SelecionarPorId(vm.Id);
        repositorioFuncionario.Excluir(vm.Id);
        return RedirectToAction(nameof(Listar));
    }
}
