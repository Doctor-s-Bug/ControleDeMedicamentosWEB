using FluentResults;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;

namespace GestaoDeMedicamentos.WebApp.ModuloMedicamento.Aplicacao;

public class ServicoMedicamento
{
    private readonly IRepositorioMedicamento repositorioMedicamento;

    public ServicoMedicamento(IRepositorioMedicamento repositorioMedicamento)
    {
        this.repositorioMedicamento = repositorioMedicamento;
    }

    


    private static Result ValidarEntidade(Medicamento medicamento)
    {
        List<string> erros = medicamento.Validar();

        if (erros.Count == 0)
            return Result.Ok();

        return Result.Fail(new FluentResults.Error(erros.First()).WithMetadata("Campo", string.Empty));
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
}
