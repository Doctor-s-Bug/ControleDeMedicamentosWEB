using FluentResults;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;

namespace GestaoDeMedicamentos.WebApp.ModuloFuncionario.Aplicacao;

public class ServicoFuncionario
{
    private readonly IRepositorioFuncionario repositorioFuncionario;

    public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario)
    {
        this.repositorioFuncionario = repositorioFuncionario;
    }

    public Result<DetalhesFuncionarioDto> SelecionarPorId(string id)
    {
        Funcionario? funcionario = repositorioFuncionario.SelecionarPorId(id);

        if (funcionario == null)
            return Result.Fail("funcionario não encontrado.");

        return Result.Ok(new DetalhesFuncionarioDto(
            funcionario.Id, funcionario.Nome, funcionario.Cpf,
            funcionario.Telefone
            ));
    }
    public List<DetalhesFuncionarioDto> SelecionarTodos()
    {
        return repositorioFuncionario
            .SelecionarTodos()
            .Select(c => new DetalhesFuncionarioDto(c.Id, c.Nome, c.Cpf,
            c.Telefone))
            .ToList();
    }
}
