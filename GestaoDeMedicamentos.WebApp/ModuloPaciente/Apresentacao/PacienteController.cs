using GestaoDeMedicamentos.WebApp.ModuloPaciente.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeMedicamentos.WebApp.ModuloPaciente.Apresentacao;

public class PacienteController : Controller
{
    private readonly IRepositorioPaciente repositorioPaciente;

    public PacienteController(IRepositorioPaciente repositorioPaciente)
    {
        this.repositorioPaciente = repositorioPaciente;
    }

    public ActionResult Listar()
    {
        List<Paciente> listaDePacientes = repositorioPaciente.SelecionarTodos();
        List<ListarPacienteViewModels> listarVm = new();

        foreach (Paciente p in listaDePacientes)
        {
            ListarPacienteViewModels vm = new(p.Id, p.Nome, p.Telefone, p.CartaoSus, p.Cpf);

            listarVm.Add(vm);
        }

        return View(listarVm);
    }

    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]

    public ActionResult Cadastrar(CadastrarPacienteViewModels vm)
    {
        Paciente novoPaciente = new(vm.Nome, vm.Telefone, vm.CartaoSus, vm.Cpf);
        repositorioPaciente.Cadastrar(novoPaciente);
        return RedirectToAction(nameof(Listar));
    }

    public ActionResult Excluir(string Id)
    {
        Paciente? paciente = repositorioPaciente.SelecionarPorId(Id);
        ExcluirPacienteViewModels vm = new(paciente.Id, paciente.Nome, paciente.Telefone, paciente.CartaoSus, paciente.Cpf);
        return View(vm);
    }

    [HttpPost]

    public ActionResult Excluir(ExcluirPacienteViewModels vm)
    {
        Paciente? pacienteExcluir = repositorioPaciente.SelecionarPorId(vm.Id);
        repositorioPaciente.Excluir(vm.Id);
        return RedirectToAction(nameof(Listar));
    }

}
