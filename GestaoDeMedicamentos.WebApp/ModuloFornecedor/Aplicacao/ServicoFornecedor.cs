using FluentResults;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Dominio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestaoDeMedicamentos.WebApp.ModuloFornecedor.Aplicacao;

public class ServicoFornecedor
{
    private readonly IRepositorioFornecedor repositorioFornecedor;

    public ServicoFornecedor(IRepositorioFornecedor repositorioFornecedor)
    {
        this.repositorioFornecedor = repositorioFornecedor;
    }

    public List<ListarFornecedorDTOS> SelecionarTodos()
    {
        return repositorioFornecedor
            .SelecionarTodos()
            .Select(c => new ListarFornecedorDTOS(c.Id, c.Nome, c.Telefone, c.Cnpj))
            .ToList();
    }
    private static Result Falha(string campo, string mensagem)
    {
        return Result.Fail(new FluentResults.Error(mensagem).WithMetadata("Campo", campo));
    }
}
