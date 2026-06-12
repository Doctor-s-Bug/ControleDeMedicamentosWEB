using GestaoDeMedicamentos.WebApp.ModuloPaciente.Dominio;

namespace GestaoDeMedicamentos.WebApp.ModuloPaciente.Aplicacao;

public class ServicoPaciente
{
    private readonly IRepositorioPaciente repositorioPaciente;

    public ServicoPaciente(IRepositorioPaciente repositorioPaciente)
    {
        this.repositorioPaciente = repositorioPaciente;
    }

    public List<DetalhesPacienteDto> SelecionarTodos()
    {
        return repositorioPaciente
            .SelecionarTodos()
            .Select(c => new DetalhesPacienteDto(c.Id, c.Nome, c.Telefone, c.Cpf,
            c.CartaoSus))
            .ToList();
    }
}
