using AutoMapper;
using FluentResults;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;

namespace GestaoDeMedicamentos.WebApp.ModuloMedicamento.Aplicacao;

public class ServicoMedicamento
{
    private readonly IRepositorioMedicamento repositorioMedicamento;
    private readonly ServicoFornecedor servicoFornecedor;
    private readonly IMapper mapper;

    public ServicoMedicamento(IRepositorioMedicamento repositorioMedicamento, ServicoFornecedor servicoFornecedor, IMapper mapper)
    {
        this.repositorioMedicamento = repositorioMedicamento;
        this.servicoFornecedor = servicoFornecedor;
        this.mapper = mapper;
    }

    public Result<CadastrarMedicamentoDto> Cadastrar(CadastrarMedicamentoDto dto)
    {
        Result<DetalhesFornecedorDto> dtosFornecedor = servicoFornecedor.SelecionarPorId(dto.Fornecedor);

        if (dtosFornecedor.IsFailed)
            return Falha(nameof(dto.Fornecedor), "Fornecedor não encontrado!");

        Fornecedor fornecedor = mapper.Map<Fornecedor>(dtosFornecedor.Value);

        Medicamento novoMedicamento = new(dto.Nome, dto.Descricao, dto.QuantidadeEstoque, fornecedor);

        Result resultadoValidacao = ValidarEntidade(novoMedicamento);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioMedicamento.Cadastrar(novoMedicamento);

        return Result.Ok();
    }

    private static Result ValidarEntidade(Medicamento medicamento)
    {
        List<string> erros = medicamento.Validar();

        if (erros.Count == 0)
            return Result.Ok();

        return Result.Fail(new Error(erros.First()).WithMetadata("Campo", string.Empty));
    }

    public Result Excluir(ExcluirMedicamentoDto dto)
    {
        Medicamento? medicamento = repositorioMedicamento.SelecionarPorId(dto.Id);

        if (medicamento == null)
            return Result.Fail("Medicamento não encontrado!");

        repositorioMedicamento.Excluir(dto.Id);

        return Result.Ok();
    }

    private static Result Falha(string campo, string mensagem)
    {
        return Result.Fail(new FluentResults.Error(mensagem).WithMetadata("Campo", campo));
    }
    public List<ListarMedicamentoDto> SelecionarTodos()
    {
        return repositorioMedicamento
            .SelecionarTodos()
            .Select(c => new ListarMedicamentoDto(c.Id, c.Nome, c.Descricao, c.QuantidadeEstoque, c.Fornecedor.Nome))
            .ToList();
    }
    public Result<DetalhesMedicamentoDto> SelecionarPorId(string id)
    {
        Medicamento? medicamento = repositorioMedicamento.SelecionarPorId(id);

        if (medicamento == null)
            return Result.Fail("Medicamento não encontrado.");

        return Result.Ok(new DetalhesMedicamentoDto(
            medicamento.Id, medicamento.Nome, medicamento.Descricao,
            medicamento.QuantidadeEstoque, medicamento.Fornecedor.Nome
            ));
    }

}
