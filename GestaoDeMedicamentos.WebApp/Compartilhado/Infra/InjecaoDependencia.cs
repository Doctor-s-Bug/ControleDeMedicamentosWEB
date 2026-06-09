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
        // services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmArquivo>();

    }
}
