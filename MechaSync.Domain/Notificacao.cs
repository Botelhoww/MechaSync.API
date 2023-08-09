namespace MechaSync.Domain;

public class Notificacao
{
    public Notificacao(int usuarioId, string mensagem)
    {
        UsuarioId = usuarioId;
        Mensagem = mensagem;
    }

    public int NotificacaoId { get; set; }
    public int UsuarioId { get; set; }
    public string Mensagem { get; set; }
    public DateTime DataEnvio { get; set; } = DateTime.Now;
}