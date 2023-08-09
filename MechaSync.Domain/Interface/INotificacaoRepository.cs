namespace MechaSync.Domain.Interface;

public interface INotificacaoRepository
{
    Notificacao ObterPorId(int id);
    IEnumerable<Notificacao> ListarPorUsuario(int usuarioId);
    void Adicionar(Notificacao notificacao);
    void Atualizar(Notificacao notificacao);
    void Remover(int id);
}