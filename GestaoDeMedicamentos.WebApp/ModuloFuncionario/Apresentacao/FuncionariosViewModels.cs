namespace GestaoDeMedicamentos.WebApp.ModuloFuncionario.Apresentacao;

public record ListarFuncionarioViewModel(
    string Id,
    string Nome,
    string Cpf,
    string Telefone
);

public record CadastrarFuncionarioViewModel(
    string Nome,
    string Cpf,
    string Telefone
);