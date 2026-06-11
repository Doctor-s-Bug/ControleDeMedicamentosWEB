namespace GestaoDeMedicamentos.WebApp.ModuloMedicamento.Aplicacao;

public record ListarMedicamentoDto(
    string Id,
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    string Fornecedor
);
