using System.ComponentModel.DataAnnotations;

namespace GestaoDeMedicamentos.WebApp.ModuloMedicamento.Apresentacao;

public record ListarMedicamentoViewModel(
    string Id,
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    string Fornecedor
);
public record CadastrarMedicamentoViewModel(
    [Required]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter entre 3 a 100 caracteres.", MinimumLength = 3)]
    string Nome,
    [Required]
    [StringLength(255, ErrorMessage = "O campo \"Nome\" deve conter entre 3 a 255 caracteres.", MinimumLength = 5)]
    string Descricao,
    [Required]
    int QuantidadeEstoque,
    [Required]
    string Fornecedor
);
public record ExcluirMedicamentoViewModel(
    string Id,
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    string Fornecedor
);
public record EditarMedicamentoViewModel(
    string Id,
    [Required]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter entre 3 a 100 caracteres.", MinimumLength = 3)]
    string Nome,
    [Required]
    [StringLength(255, ErrorMessage = "O campo \"Nome\" deve conter entre 3 a 255 caracteres.", MinimumLength = 5)]
    string Descricao,
    [Required]
    int QuantidadeEstoque,
    [Required]
    string Fornecedor
);