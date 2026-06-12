using GestaoDeMedicamentos.WebApp.Compartilhado.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;

namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Dominio;

public class EntradaEstoque : EntidadeBase<EntradaEstoque>
{
    public DateTime DataEntrada { get; set; } = DateTime.Now;
    public Medicamento Medicamento { get; set; }
    public Funcionario Funcionario { get; set; }
    public int QuantidadeEntrada { get; set; }

    public EntradaEstoque()
    {
    }

    public EntradaEstoque(Medicamento medicamento, Funcionario funcionario, int quantidadeEntrada)
    {
        Medicamento = medicamento;
        Funcionario = funcionario;
        QuantidadeEntrada = quantidadeEntrada;
    }

    public override List<String> Validar()
    {
        List<string> erros = new();

        if (Medicamento == null)
            erros.Add("O campo \"Medicamento\" não pode ser vazio!");

        if (Funcionario == null)
            erros.Add("O campo \"Funcionario\" não pode ser vazio!");

        if (QuantidadeEntrada <= 0)
            erros.Add("O campo \"Quantidade\" deve ser maior que zero!");

        return erros;
    }
    
    public override void Atualizar(EntradaEstoque entidadeAtualizada)
    {
        throw new NotImplementedException();
    }
}
