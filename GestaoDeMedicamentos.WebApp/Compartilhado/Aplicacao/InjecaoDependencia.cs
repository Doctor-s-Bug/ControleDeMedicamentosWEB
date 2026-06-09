using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Aplicacao;

namespace GestaoDeMedicamentos.WebApp.Compartilhado.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddAplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ServicoFornecedor>();
    }
}
