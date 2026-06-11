namespace GestaoDeMedicamentos.WebApp.ModuloMedicamento.Aplicacao;

public record ListarMedicamentoDto(
    string Id,
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    string Fornecedor
);
public record CadastrarMedicamentoDto(
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    string Fornecedor
);
public record DetalhesMedicamentoDto(
    string Id,
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    string Fornecedor
);
public record ExcluirMedicamentoDto(
    string Id,
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    string Fornecedor
);