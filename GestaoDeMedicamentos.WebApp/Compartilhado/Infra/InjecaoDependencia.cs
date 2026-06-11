using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Infra;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Infra;
using GestaoDeMedicamentos.WebApp.ModuloPaciente.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloPaciente.Infra;

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
        services.AddScoped<IRepositorioMedicamento, RepositorioMedicamentoEmArquivo>();
        services.AddScoped<IRepositorioPaciente, RepositorioPacienteEmArquivo>();
    }
}
