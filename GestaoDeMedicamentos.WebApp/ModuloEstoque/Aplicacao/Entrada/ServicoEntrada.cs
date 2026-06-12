namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Entrada;

using AutoMapper;
using FluentResults;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Dominio.Entrada;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;

public class ServicoEntrada
{
    private readonly IRepositorioMedicamento repositorioMedicamento;
    private readonly IRepositorioFuncionario repositorioFuncionario;
    private readonly ServicoFuncionario servicoFuncionario;
    private readonly ServicoMedicamento servicoMedicamento;
    private readonly ServicoFornecedor servicoFornecedor;
    private readonly IRepositorioEntrada repositorioEntrada;
    private readonly IMapper mapper;

    public ServicoEntrada(IMapper mapper, ServicoFuncionario servicoFuncionario, ServicoMedicamento servicoMedicamento, IRepositorioEntrada repositorioEntrada, ServicoFornecedor servicoFornecedor, IRepositorioMedicamento repositorioMedicamento, IRepositorioFuncionario repositorioFuncionario)
    {
        this.mapper = mapper;
        this.servicoFuncionario = servicoFuncionario;
        this.servicoMedicamento = servicoMedicamento;
        this.repositorioEntrada = repositorioEntrada;
        this.servicoFornecedor = servicoFornecedor;
        this.repositorioMedicamento = repositorioMedicamento;
        this.repositorioFuncionario = repositorioFuncionario;
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

    public Result Cadastrar(CadastrarEntradaDto dto)
    {
        //aqui da erro pq ele tenta pegar a string do fornecedor do Dto e colocar no medicamento
        Funcionario? funcionario = repositorioFuncionario.SelecionarPorId(dto.Funcionario);

        if (funcionario == null)
            return Result.Fail("Funcionario não encontrado.");

        Medicamento? medicamento = repositorioMedicamento.SelecionarPorId(dto.Medicamento);

        if (medicamento == null)
            return Result.Fail("Medicamento não encontrado.");

        EntradaEstoque entradaEstoque = new(medicamento, funcionario, dto.Quantidade);

        repositorioEntrada.Cadastrar(entradaEstoque);

        Medicamento medicamentoAtualizado = medicamento;

        medicamentoAtualizado.QuantidadeEstoque += entradaEstoque.QuantidadeEntrada;

        repositorioMedicamento.Editar(medicamento.Id, medicamentoAtualizado);

        return Result.Ok();
    }

    private static Result Falha(string campo, string mensagem)
    {
        return Result.Fail(new FluentResults.Error(mensagem).WithMetadata("Campo", campo));
    }
}
