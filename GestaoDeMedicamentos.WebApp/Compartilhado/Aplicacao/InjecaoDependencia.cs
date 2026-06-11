using GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Entrada;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Saida;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Aplicacao;

namespace GestaoDeMedicamentos.WebApp.Compartilhado.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddAplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ServicoFornecedor>();
        services.AddScoped<ServicoMedicamento>();
        services.AddScoped<ServicoEntrada>();
        services.AddScoped<ServicoSaida>();
        services.AddScoped<ServicoFuncionario>();
    }
}
