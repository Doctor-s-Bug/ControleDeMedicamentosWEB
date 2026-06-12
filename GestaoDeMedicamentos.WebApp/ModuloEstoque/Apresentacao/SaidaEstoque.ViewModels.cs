namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Apresentacao.Views;

public record ListarSaidaViewModel(
    string Id,
    string Data,
    string Medicamento,
    string Paciente,
    int Quantidade
);
