using AutoMapper;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Aplicacao;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeMedicamentos.WebApp.ModuloMedicamento.Apresentacao;

public class MedicamentoController : Controller
{
    private readonly ServicoMedicamento servicoMedicamento;
    private readonly IMapper mapper;

    public MedicamentoController(ServicoMedicamento servicoMedicamento, IMapper mapper = null)
    {
        this.servicoMedicamento = servicoMedicamento;
        this.mapper = mapper;
    }

    public ActionResult Listar()
    {
        List<ListarMedicamentoDto> dtos = servicoMedicamento.SelecionarTodos();

        List<ListarMedicamentoViewModel> vms = mapper.Map<List<ListarMedicamentoViewModel>>(dtos);

        return View(vms);
    }
}
