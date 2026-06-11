using AutoMapper;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Entrada;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Saida;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Apresentacao;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Apresentacao;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Apresentacao;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Apresentacao;

public class EstoqueController : Controller
{
    private readonly ServicoEntrada servicoEntrada;
    private readonly ServicoSaida servicoSaida;
    private readonly IMapper mapper;
    private readonly ServicoFuncionario servicoFuncionario;
    private readonly ServicoMedicamento servicoMedicamento;

    public EstoqueController(ServicoEntrada serivicoEntrada, ServicoSaida servicoSaida, IMapper mapper, ServicoMedicamento servicoMedicamento, ServicoFuncionario servicoFuncionario)
    {
        this.servicoEntrada = serivicoEntrada;
        this.servicoSaida = servicoSaida;
        this.mapper = mapper;
        this.servicoMedicamento = servicoMedicamento;
        this.servicoFuncionario = servicoFuncionario;
    }
    public ActionResult ListarEntrada()
    {
        List<ListarEntradaDto> dots = servicoEntrada.SelecionarTodos();
        List<ListarEntradaViewModel> vms = mapper.Map<List<ListarEntradaViewModel>>(dots);



        return View(vms);
    }
    public ActionResult CadastrarEntrada()
    {
        List<DetalhesFuncionarioDto> dtosFuncionario = servicoFuncionario.SelecionarTodos();
        ViewBag.Funcionarios = mapper.Map<List<ListarFuncionarioViewModel>>(dtosFuncionario);

        List<ListarMedicamentoDto> dtosMedicameto = servicoMedicamento.SelecionarTodos();
        ViewBag.Medicamentos = mapper.Map<List<ListarMedicamentoViewModel>>(dtosMedicameto);

        return View();
    }
    
}
