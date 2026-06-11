using AutoMapper;
using FluentResults;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Aplicacao;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Dominio;

namespace GestaoDeMedicamentos.WebApp.ModuloFornecedor.Apresentacao;

public class FornecedorProfile : Profile
{
    public FornecedorProfile()
    {
        CreateMap<ListarFornecedorDTOS, ListarFornecedorViewModel>();
        CreateMap<DetalhesFornecedorDto, ExcluirFornecedorViewModel>();
        CreateMap<EditarFornecedorDTOs, Fornecedor>();
        CreateMap<EditarFornecedorDTOs, DetalhesFornecedorDto>();
        CreateMap<DetalhesFornecedorDto, EditarFornecedorViewModel>();
        CreateMap<DetalhesFornecedorDto, Fornecedor>();
    }
}
