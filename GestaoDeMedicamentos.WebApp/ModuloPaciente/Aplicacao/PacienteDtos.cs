namespace GestaoDeMedicamentos.WebApp.ModuloPaciente.Aplicacao;

public record DetalhesPacienteDto(
    string Id,
    string Nome,
    string Telefone,
    string Cpf,
    string CartaoSus
);
