using AutoMapper;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Aplicacao;

namespace GestaoDeMedicamentos.WebApp.ModuloFuncionario.Apresentacao;

public class FuncionarioProfile : Profile
{
    public FuncionarioProfile()
    {
        CreateMap<DetalhesFuncionarioDto, ListarFuncionarioViewModel>();
    }
}
