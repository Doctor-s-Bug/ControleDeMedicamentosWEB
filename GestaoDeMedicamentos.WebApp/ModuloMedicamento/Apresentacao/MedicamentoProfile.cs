using AutoMapper;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Apresentacao;

namespace GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;

public class MedicamentoProfile : Profile
{
    public MedicamentoProfile()
    {
        CreateMap<ListarMedicamentoDto, ListarMedicamentoViewModel>();
        CreateMap<DetalhesMedicamentoDto, ExcluirMedicamentoViewModel>();
    }
}