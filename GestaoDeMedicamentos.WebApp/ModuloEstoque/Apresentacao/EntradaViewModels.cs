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
    [Required]
    string Medicamento,
    [Required]
    string Funcionario,
    [Required]
    int Quantidade
);