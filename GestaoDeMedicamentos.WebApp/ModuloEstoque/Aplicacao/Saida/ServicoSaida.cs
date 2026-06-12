using GestaoDeMedicamentos.WebApp.ModuloEstoque.Dominio.Saida;

namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Saida;

public class ServicoSaida
{
    private readonly IRepositorioSaida repositorioSaida;

    public ServicoSaida(IRepositorioSaida repositorioSaida)
    {
        this.repositorioSaida = repositorioSaida;
    }

    public List<ListarSaidaDto> SelecionarTodos()
    {
        return repositorioSaida
            .SelecionarTodos()
            .Select(c => new ListarSaidaDto(
                c.Id, c.Data.ToShortTimeString(), c.Medicamento.Nome, c.Paciente.Nome, c.QuantidadeSaida
                ))
            .ToList();
    }
}
