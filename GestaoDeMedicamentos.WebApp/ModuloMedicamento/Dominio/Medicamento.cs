using GestaoDeMedicamentos.WebApp.Compartilhado.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Dominio;

namespace GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;

public class Medicamento : EntidadeBase<Medicamento>
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int QuantidadeEstoque { get; set; }
    public Fornecedor Fornecedor { get; set; }

    public Medicamento()
    {

    }
    public Medicamento(string nome, string descricao, int quantidadeEstoque, Fornecedor fornecedor)
    {
        Nome = nome;
        Descricao = descricao;
        QuantidadeEstoque = quantidadeEstoque;
        Fornecedor = fornecedor;
    }
    public override void Atualizar(Medicamento entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Descricao = entidadeAtualizada.Descricao;
        QuantidadeEstoque = entidadeAtualizada.QuantidadeEstoque;
        Fornecedor = entidadeAtualizada.Fornecedor;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (String.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo NOME não pode ser Null!");

        else if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("Nome deve conter entre 3 a 100 caracteres!");

        if (String.IsNullOrWhiteSpace(Descricao))
            erros.Add("O campo DESCRICAO não pode ser Null!");

        else if (Descricao.Length < 5 || Descricao.Length > 255)
            erros.Add("O campo DESCRICAO deve conter entre 5 a 255 caracteres!");

        if (QuantidadeEstoque <= 0)
            erros.Add("O campo QUANTIDADE deve ser maior que 0!");

        if (Fornecedor == null)
            erros.Add("O campo FORNECEDOR não pode ser NULO");

        return erros;
    }
}
