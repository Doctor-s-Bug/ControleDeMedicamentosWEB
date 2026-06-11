namespace GestaoDeMedicamentos.WebApp.ModuloPaciente.Apresentacao;

public record ListarPacienteViewModels(string Id, string Nome, string Telefone, string CartaoSus, string Cpf);

public record CadastrarPacienteViewModels(string Nome, string Telefone, string CartaoSus, string Cpf);

public record ExcluirPacienteViewModels(string Id, string Nome, string Telefone, string CartaoSus, string Cpf);
