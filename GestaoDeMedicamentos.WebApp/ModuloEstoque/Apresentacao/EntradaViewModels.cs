using System.ComponentModel.DataAnnotations;

namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Apresentacao;

public record ListarEntradaViewModel(
    string Id,
    string Data,
    string Medicamento,
    string Funcionario,
    int Quantidade
);
public record CadastrarEntradaViewModel(
    [Required(ErrorMessage = "O campo \"Medicamento\" é obrigatório!")]
    string Medicamento,
    [Required(ErrorMessage = "O campo \"Funcionario\" é obrigatório!")]
    string Funcionario,
    [Required(ErrorMessage = "O campo \"Quantidade Entrada\" é obrigatório!")]
    int Quantidade
);