using AutoMapper;
using FluentResults;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Dominio;

namespace GestaoDeMedicamentos.WebApp.ModuloFornecedor.Aplicacao;

public class ServicoFornecedor
{
    public readonly IMapper mapper;

    private readonly IRepositorioFornecedor repositorioFornecedor;

    public ServicoFornecedor(IRepositorioFornecedor repositorioFornecedor, IMapper mapper)
    {
        this.repositorioFornecedor = repositorioFornecedor;
        this.mapper = mapper;
    }

    public Result Cadastrar(CadastrarFornecedorDTOs dto)
    {
        Fornecedor novoFornecedor = new(dto.Nome, dto.Telefone, dto.Cnpj);

        if (ExisteOutroFornecedorComCnpj(dto.Cnpj))
            return Falha(nameof(dto.Cnpj), "Já existe um Fornecedor com este CNPJ.");

        Result resultadoValidacao = ValidarEntidade(novoFornecedor);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioFornecedor.Cadastrar(novoFornecedor);

        return Result.Ok();
    }
    public Result Excluir(string Id)
    {
        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(Id);

        if (fornecedor == null)
            return Result.Fail("Fornecedor não Encontrado");

        repositorioFornecedor.Excluir(Id);

        return Result.Ok();
    }
    public Result Editar(EditarFornecedorDTOs vm)
    {
        DetalhesFornecedorDto dto = mapper.Map<DetalhesFornecedorDto>(vm);

        Result<DetalhesFornecedorDto> resultado = SelecionarPorId(vm.Id);

        if (resultado.IsFailed)
            return Result.Fail("Fornecedor não Encontrado");

        if (ExisteOutroFornecedorComCnpj(dto.Cnpj, dto.Id))
            return Falha(nameof(dto.Cnpj), "Já existe um Fornecedor com este CNPJ.");

        Fornecedor fornecedorEditado = mapper.Map<Fornecedor>(vm);

        Result resultadoValidacao = ValidarEntidade(fornecedorEditado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioFornecedor.Editar(dto.Id, fornecedorEditado);

        return Result.Ok();
    }
    public Result<DetalhesFornecedorDto> SelecionarPorId(string id)
    {
        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(id);

        if (fornecedor == null)
            return Result.Fail("Fornecedor não encontrada.");

        return Result.Ok(new DetalhesFornecedorDto(fornecedor.Id, fornecedor.Nome, fornecedor.Telefone, fornecedor.Cnpj));
    }
    private static Result ValidarEntidade(Fornecedor fornecedor)
    {
        List<string> erros = fornecedor.Validar();

        if (erros.Count == 0)
            return Result.Ok();

        return Result.Fail(new FluentResults.Error(erros.First()).WithMetadata("Campo", string.Empty));
    }
    private static Result Falha(string campo, string mensagem)
    {
        return Result.Fail(new FluentResults.Error(mensagem).WithMetadata("Campo", campo));
    }
    private bool ExisteOutroFornecedorComCnpj(string cnpj, string? fornecedorId = null)
    {
        return repositorioFornecedor
            .SelecionarTodos()
            .Any(f =>
                f.Id != fornecedorId &&
                string.Equals(f.Cnpj, cnpj, StringComparison.OrdinalIgnoreCase)
            );
    }
    public List<ListarFornecedorDTOS> SelecionarTodos()
    {
        return repositorioFornecedor
            .SelecionarTodos()
            .Select(c => new ListarFornecedorDTOS(c.Id, c.Nome, c.Telefone, c.Cnpj))
            .ToList();
    }

}
