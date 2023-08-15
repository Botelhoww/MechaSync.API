namespace MechaSync.Domain;

public class Agendamento
{
    public Agendamento(int usuarioId, int veiculoId, DateTime dataAgendamento, string descricao, string status)
    {
        UsuarioId = usuarioId;
        VeiculoId = veiculoId;
        DataAgendamento = dataAgendamento;
        Descricao = descricao;
        Status = status;
    }

    public int AgendamentoId { get; set; }
    public int UsuarioId { get; set; }
    public int VeiculoId { get; set; }
    public DateTime DataAgendamento { get; set; }
    public string Descricao { get; set; }
    public string Status { get; set; }
}