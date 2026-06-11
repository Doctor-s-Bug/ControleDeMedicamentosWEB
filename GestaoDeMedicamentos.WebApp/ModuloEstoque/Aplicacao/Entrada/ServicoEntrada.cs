namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Entrada;

using AutoMapper;
using FluentResults;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Dominio.Entrada;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Aplicacao;

public class ServicoEntrada
{
    private readonly ServicoFuncionario servicoFuncionario;
    private readonly ServicoMedicamento servicoMedicamento;
    private readonly IRepositorioEntrada repositorioEntrada;
    private readonly IMapper mapper;

    public ServicoEntrada(IMapper mapper, ServicoFuncionario servicoFuncionario, ServicoMedicamento servicoMedicamento, IRepositorioEntrada repositorioEntrada)
    {
        this.mapper = mapper;
        this.servicoFuncionario = servicoFuncionario;
        this.servicoMedicamento = servicoMedicamento;
        this.repositorioEntrada = repositorioEntrada;
    }

    public List<ListarEntradaDto> SelecionarTodos()
    {
        return repositorioEntrada
            .SelecionarTodos()
            .Select(c => new ListarEntradaDto(
                c.Id, c.DataEntrada.ToShortTimeString(), c.Medicamento.Nome, c.Funcionario.Nome, c.QuantidadeEntrada
                ))
            .ToList();
    }
}
