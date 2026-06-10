using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Infra;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Dominio;

namespace GestaoDeMedicamentos.WebApp.Compartilhado.Infra.Arquivos;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(this IServiceCollection services)
    {
        services.AddScoped(provider =>
        {
            ContextoJson contextoJson = new ContextoJson();

            contextoJson.Carregar();

            return contextoJson;
        });
        services.AddScoped<IRepositorioFornecedor, RepositorioFornecedorEmArquivo>();

        services.AddScoped<IRepositorioFuncionario, RepositorioFuncionarioEmArquivo>();
    }
}
