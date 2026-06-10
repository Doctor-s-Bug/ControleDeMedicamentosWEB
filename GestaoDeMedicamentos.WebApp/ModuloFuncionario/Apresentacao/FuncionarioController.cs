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
}
