using GestaoDeMedicamentos.WebApp.Compartilhado.Infra.Arquivos;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;

namespace GestaoDeMedicamentos.WebApp.ModuloMedicamento.Infra;

public class RepositorioMedicamentoEmArquivo : RepositorioBaseEmArquivo<Medicamento>, IRepositorioMedicamento
{
    public RepositorioMedicamentoEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Medicamento> CarregarRegistros()
    {
        return contexto.Medicamentos;
    }
}
