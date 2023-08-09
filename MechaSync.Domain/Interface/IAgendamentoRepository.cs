namespace MechaSync.Domain.Interface;

public interface IAgendamentoRepository
{
    Agendamento ObterPorId(int id);
    IEnumerable<Agendamento> ListarPorUsuario(int usuarioId);
    void Adicionar(Agendamento agendamento);
    void Atualizar(Agendamento agendamento);
    void Remover(int id);
}