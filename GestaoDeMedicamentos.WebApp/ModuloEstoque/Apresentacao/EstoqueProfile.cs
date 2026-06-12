using AutoMapper;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Aplicacao.Saida;
using GestaoDeMedicamentos.WebApp.ModuloEstoque.Apresentacao.Views;

namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Apresentacao;

public class EstoqueProfile : Profile
{
    public EstoqueProfile()
    {
        CreateMap<ListarSaidaDto, ListarSaidaViewModel>();
    }
}
