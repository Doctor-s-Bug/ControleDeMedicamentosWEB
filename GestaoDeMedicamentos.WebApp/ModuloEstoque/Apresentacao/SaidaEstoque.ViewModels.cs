using System.ComponentModel.DataAnnotations;

namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Apresentacao.Views;

public record ListarSaidaViewModel(
    string Id,
    string Data,
    string Medicamento,
    string Paciente,
    int Quantidade
);
public record CadastrarsSaidaViewModel(

    [Required(ErrorMessage = "O campo \"Paciente\" é obrigatório!")]
    string Paciente,
    [Required(ErrorMessage = "O campo \"Medicamento\" é obrigatório!")]
    string Medicamento,
    [Required(ErrorMessage = "O campo \"Quantidade Entrada\" é obrigatório!")]
    int QuantidadeSaida
);
