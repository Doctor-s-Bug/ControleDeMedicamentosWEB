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
        return View();
    }
}
