using GestaoDeMedicamentos.WebApp.Compartilhado.Infra.Arquivos;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Dominio.Saida;

namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Infra;

public class RepositorioSaida : RepositorioBaseEmArquivo<SaidaEstoque>, IRepositorioSaida
{
    public RepositorioSaida(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<SaidaEstoque> CarregarRegistros()
    {
        return contexto.EstoqueSaidas;
    }
}
