using System.Security.Cryptography;
using GestaoDeMedicamentos.WebApp.Compartilhado.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloPaciente.Dominio;

namespace GestaoDeMedicamentos.WebApp.ModuloEstoque.Dominio.Saida;

public class SaidaEstoque : EntidadeBase<SaidaEstoque>
{
    public DateTime Data { get; set; } = DateTime.Now;
    public Paciente Paciente { get; set; }
    public Medicamento Medicamento { get; set; }
    public int QuantidadeSaida { get; set; }
    public SaidaEstoque()
    {
    }
    public SaidaEstoque(Paciente paciente, Medicamento medicamento, int quantidadeSaida)
    {
        Paciente = paciente;
        Medicamento = medicamento;
        QuantidadeSaida = quantidadeSaida;
    }
    public override List<string> Validar()
    {
        List<string> erros = new();

        if (Medicamento == null)
            erros.Add("O campo \"Medicamento\" não pode ser vazio!");

        if (Paciente == null)
            erros.Add("O campo \"Paciente\" não pode ser vazio!");

        return erros;
    }

    public override void Atualizar(SaidaEstoque entidadeAtualizada)
    {
        throw new NotImplementedException();
    }
}
