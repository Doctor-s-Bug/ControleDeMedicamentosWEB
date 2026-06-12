using FluentResults;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Dominio.Saida;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloPaciente.Dominio;

namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Saida;

public class ServicoSaida
{
    private readonly IRepositorioSaida repositorioSaida;
    private readonly IRepositorioPaciente repositorioPaciente;
    private readonly IRepositorioMedicamento repositorioMedicamento;

    public ServicoSaida(IRepositorioSaida repositorioSaida, IRepositorioPaciente repositorioPaciente, IRepositorioMedicamento repositorioMedicamento)
    {
        this.repositorioSaida = repositorioSaida;
        this.repositorioPaciente = repositorioPaciente;
        this.repositorioMedicamento = repositorioMedicamento;
    }

    public List<ListarSaidaDto> SelecionarTodos()
    {
        return repositorioSaida
            .SelecionarTodos()
            .Select(c => new ListarSaidaDto(
                c.Id, c.Data.ToShortTimeString(), c.Medicamento.Nome, c.Paciente.Nome, c.QuantidadeSaida
                ))
            .ToList();
    }

    public Result Cadastrar(CadastrarSaidaDto dto)
    {
        Medicamento? medicamento = repositorioMedicamento.SelecionarPorId(dto.Medicamento);

        if (medicamento == null)
            return Result.Fail("Medicamento não encontrado.");

        Paciente? paciente = repositorioPaciente.SelecionarPorId(dto.Paciente);

        if (paciente == null)
            return Result.Fail("Paciente não encontrado.");

        if (dto.QuantidadeSaida > medicamento.QuantidadeEstoque)
            return Result.Fail("A quantidade de Retirada é MAIOR que o Estoque do Medicamento!");

        SaidaEstoque saidaEstoque = new(paciente, medicamento, dto.QuantidadeSaida);

        medicamento.QuantidadeEstoque -= dto.QuantidadeSaida;

        repositorioSaida.Cadastrar(saidaEstoque);

        return Result.Ok();
    }
}
