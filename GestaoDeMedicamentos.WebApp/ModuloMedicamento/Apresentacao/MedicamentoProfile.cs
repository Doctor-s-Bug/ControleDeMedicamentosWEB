using AutoMapper;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Aplicacao;

namespace GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;

public class MedicamentoProfile : Profile
{
    public MedicamentoProfile()
    {
        CreateMap<ListarMedicamentoDto, ListarMedicamentoDto>();
    }
}