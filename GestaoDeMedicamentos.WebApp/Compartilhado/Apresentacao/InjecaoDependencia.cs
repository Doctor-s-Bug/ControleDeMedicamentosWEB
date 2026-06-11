using GestaoDeMedicamentos.WebApp.ModuloEstoque.Apresentacao;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Apresentacao;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Apresentacao;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;

namespace GestaoDeMedicamentos.WebApp.Compartilhado.Apresentacao;

public static class InjecaoDependencia
{
    public static void AddPresentation(this IServiceCollection services)
    {
        services.AddControllersWithViews().AddRazorOptions(options =>
    {
        // Reseta a configuração padrão do MVC
        options.ViewLocationFormats.Clear();

        // Localização das Views dos módulos: /ModuloCaixa/Apresentacao/Views/Listar.cshtml
        options.ViewLocationFormats.Add("/Modulo{1}/Apresentacao/Views/{0}.cshtml");

        // Localização das Views compartilhadas: /Compartilhado/Apresentacao/Views/_Layout.cshtml
        options.ViewLocationFormats.Add("/Compartilhado/Apresentacao/Views/{0}.cshtml");
    });

        services.AddAutoMapper(config =>
        {
            config.AddProfile<FornecedorProfile>();
            config.AddProfile<MedicamentoProfile>();
            config.AddProfile<EntradaProfile>();
            config.AddProfile<FuncionarioProfile>();
            config.AddMaps(typeof(Program));
        });
    }
}
