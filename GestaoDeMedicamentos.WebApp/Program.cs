using GestaoDeMedicamentos.WebApp.Compartilhado.Aplicacao;
using GestaoDeMedicamentos.WebApp.Compartilhado.Apresentacao;
using GestaoDeMedicamentos.WebApp.Compartilhado.Infra.Arquivos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraRepositories();
builder.Services.AddAplicationServices();
builder.Services.AddPresentation();

var app = builder.Build();

// Configuração de Middlewares
app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();

// Execução do Servidor
app.Run();
