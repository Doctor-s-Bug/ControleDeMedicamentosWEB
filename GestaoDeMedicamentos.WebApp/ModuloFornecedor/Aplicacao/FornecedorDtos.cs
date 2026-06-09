namespace GestaoDeMedicamentos.WebApp.ModuloFornecedor.Aplicacao;

public record ListarFornecedorDTOS(
    string Id,
    string Nome,
    string Telefone,
    string Cnpj
);
public record CadastrarFornecedorDTOs(
    string Nome,
    string Telefone,
    string Cnpj
);