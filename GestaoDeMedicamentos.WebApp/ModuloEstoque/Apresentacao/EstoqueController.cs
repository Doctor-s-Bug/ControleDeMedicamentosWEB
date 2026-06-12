using AutoMapper;
using FluentResults;
using GestaoDeMedicamentos.WebApp.Compartilhado.Apresentacao.Extensions;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Entrada;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Saida;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Apresentacao.Views;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Apresentacao;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Apresentacao;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Apresentacao;
using GestaoDeMedicamentos.WebApp.ModuloPaciente.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloPaciente.Apresentacao;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Apresentacao;

public class EstoqueController : Controller
{
    private readonly ServicoEntrada servicoEntrada;
    private readonly ServicoSaida servicoSaida;
    private readonly ServicoFuncionario servicoFuncionario;
    private readonly ServicoMedicamento servicoMedicamento;
    private readonly ServicoPaciente servicoPaciente;
    private readonly IMapper mapper;

    public EstoqueController(
        ServicoEntrada serivicoEntrada,
        ServicoSaida servicoSaida, IMapper mapper,
        ServicoMedicamento servicoMedicamento,
        ServicoFuncionario servicoFuncionario,
        ServicoPaciente servicoPaciente)
    {
        this.servicoEntrada = serivicoEntrada;
        this.servicoSaida = servicoSaida;
        this.mapper = mapper;
        this.servicoMedicamento = servicoMedicamento;
        this.servicoFuncionario = servicoFuncionario;
        this.servicoPaciente = servicoPaciente;
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
    [HttpPost]
    public ActionResult CadastrarEntrada(CadastrarEntradaViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            List<DetalhesFuncionarioDto> dtosFuncionario = servicoFuncionario.SelecionarTodos();
            ViewBag.Funcionarios = mapper.Map<List<ListarFuncionarioViewModel>>(dtosFuncionario);

            List<ListarMedicamentoDto> dtosMedicameto = servicoMedicamento.SelecionarTodos();
            ViewBag.Medicamentos = mapper.Map<List<ListarMedicamentoViewModel>>(dtosMedicameto);
            return View(vm);
        }

        CadastrarEntradaDto dto = new(vm.Medicamento, vm.Funcionario, vm.Quantidade);

        Result resultado = servicoEntrada.Cadastrar(dto);

        return RedirectToAction(nameof(ListarEntrada));
    }
    public ActionResult ListarSaida()
    {
        List<ListarSaidaDto> dots = servicoSaida.SelecionarTodos();
        List<ListarSaidaViewModel> vms = mapper.Map<List<ListarSaidaViewModel>>(dots);

        return View(vms);
    }
    public ActionResult CadastrarSaida()
    {
        List<DetalhesPacienteDto> dtosPaciente = servicoPaciente.SelecionarTodos();
        ViewBag.Pacientes = mapper.Map<List<ListarPacienteViewModels>>(dtosPaciente);

        List<ListarMedicamentoDto> dtosMedicameto = servicoMedicamento.SelecionarTodos();
        ViewBag.Medicamentos = mapper.Map<List<ListarMedicamentoViewModel>>(dtosMedicameto);

        return View();
    }
    [HttpPost]
    public ActionResult CadastrarSaida(CadastrarsSaidaViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            List<DetalhesPacienteDto> dtosPaciente = servicoPaciente.SelecionarTodos();
            ViewBag.Pacientes = mapper.Map<List<ListarPacienteViewModels>>(dtosPaciente);

            List<ListarMedicamentoDto> dtosMedicameto = servicoMedicamento.SelecionarTodos();
            ViewBag.Medicamentos = mapper.Map<List<ListarMedicamentoViewModel>>(dtosMedicameto);
            return View(vm);
        }

        CadastrarSaidaDto dto = new(vm.Paciente, vm.Medicamento, vm.QuantidadeSaida);

        Result resultado = servicoSaida.Cadastrar(dto);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(ListarSaida));

    }
}
