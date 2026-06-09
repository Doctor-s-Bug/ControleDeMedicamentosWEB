using GestaoDeMedicamentos.WebApp.Compartilhado.Infra.Arquivos;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Dominio;

namespace GestaoDeMedicamentos.WebApp.ModuloFornecedor.Infra;

public class RepositorioFornecedorEmArquivo : RepositorioBaseEmArquivo<Fornecedor>, IRepositorioFornecedor
{
    public RepositorioFornecedorEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Fornecedor> CarregarRegistros()
    {
        return contexto.Fornecedores;
    }
}
