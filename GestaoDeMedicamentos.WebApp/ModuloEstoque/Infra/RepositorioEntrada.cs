using GestaoDeMedicamentos.WebApp.Compartilhado.Infra.Arquivos;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Dominio.Entrada;

namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Infra;

public class RepositorioEntrada : RepositorioBaseEmArquivo<EntradaEstoque>, IRepositorioEntrada
{
    public RepositorioEntrada(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<EntradaEstoque> CarregarRegistros()
    {
        return contexto.EstoqueEntradas;
    }
}
