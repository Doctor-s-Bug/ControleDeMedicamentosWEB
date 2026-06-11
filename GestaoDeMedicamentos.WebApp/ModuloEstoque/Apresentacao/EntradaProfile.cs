using AutoMapper;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Entrada;

namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Apresentacao;

public class EntradaProfile : Profile
{
    public EntradaProfile()
    {
        CreateMap<ListarEntradaDto, ListarEntradaViewModel>();
    }
}
