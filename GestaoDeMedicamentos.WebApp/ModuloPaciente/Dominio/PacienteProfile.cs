using AutoMapper;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloPaciente.Apresentacao;

namespace GestaoDeMedicamentos.WebApp.ModuloPaciente.Dominio;

public class PacienteProfile : Profile
{
    public PacienteProfile()
    {
        CreateMap<DetalhesFuncionarioDto, ListarPacienteViewModels>();
    }
}
