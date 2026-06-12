namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Saida;

public record ListarSaidaDto(
    string Id,
    string Data,
    string Medicamento,
    string Paciente,
    int Quantidade
);
public record CadastrarSaidaDto(
    string Paciente,
    string Medicamento,
    int QuantidadeSaida
);
