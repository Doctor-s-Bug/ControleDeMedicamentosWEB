namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Apresentacao;

public record ListarEntradaViewModel(
    string Id,
    string Data,
    string Medicamento,
    string Funcionario,
    int Quantidade
);
public record CadastrarEntradaViewModel(
    string Medicamento,
    string Funcionario,
    int Quantidade
);