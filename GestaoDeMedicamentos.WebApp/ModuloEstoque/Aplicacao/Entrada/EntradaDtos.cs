

namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Entrada;

public record ListarEntradaDto(
    string Id,
    string Data,
    string Medicamento,
    string Funcionario,
    int Quantidade
);
public record CadastrarEntradaDto(
    string Medicamento,
    string Funcionario,
    int Quantidade
);