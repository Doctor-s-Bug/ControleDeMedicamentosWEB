using AutoMapper;
using GestaoDeMedicamentos.WebApp.ModuloPaciente.Aplicacao;

namespace GestaoDeMedicamentos.WebApp.ModuloPaciente.Apresentacao;

public class PacienteProfile : Profile
{
    public PacienteProfile()
    {
        CreateMap<DetalhesPacienteDto, ListarPacienteViewModels>();
    }
}
