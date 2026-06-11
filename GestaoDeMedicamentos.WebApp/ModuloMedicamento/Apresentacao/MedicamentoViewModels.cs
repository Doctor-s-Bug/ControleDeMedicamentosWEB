namespace GestaoDeMedicamentos.WebApp.ModuloMedicamento.Apresentacao;

public record ListarMedicamentoViewModel(
    string Id,
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    string Fornecedor
);