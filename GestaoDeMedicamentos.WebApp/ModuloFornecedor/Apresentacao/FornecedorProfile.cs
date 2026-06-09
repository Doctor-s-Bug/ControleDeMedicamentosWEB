using AutoMapper;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Aplicacao;

namespace GestaoDeMedicamentos.WebApp.ModuloFornecedor.Apresentacao;

public class FornecedorProfile : Profile
{
    public FornecedorProfile()
    {
        CreateMap<ListarFornecedorDTOS, ListarFornecedorViewModel>();
    }
}
