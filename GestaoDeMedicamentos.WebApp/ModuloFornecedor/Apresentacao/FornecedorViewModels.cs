using System.ComponentModel.DataAnnotations;

namespace GestaoDeMedicamentos.WebApp.ModuloFornecedor.Apresentacao;

public record ListarFornecedorViewModel(
    string Id,
    string Nome,
    string Telefone,
    string Cnpj
);
public record CadastrarFornecedorViewModel(
    [Required]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter entre 3 a 100 caracteres.", MinimumLength = 3)]
    string Nome,
    [Required]
    string Telefone,
    [Required]
    [StringLength(14, ErrorMessage = "O campo \"CNPJ\" deve conter 14 caracteres.")]
    string Cnpj
);
public record ExcluirFornecedorViewModel(
    string Id,
    string Nome,
    string Telefone,
    string Cnpj
);
public record EditarFornecedorViewModel(
    string Id,
    [Required]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter entre 3 a 100 caracteres.", MinimumLength = 3)]
    string Nome,
    [Required]
    string Telefone,
    [Required]
    [StringLength(14, ErrorMessage = "O campo \"CNPJ\" deve conter 14 caracteres.")]
    string Cnpj
);