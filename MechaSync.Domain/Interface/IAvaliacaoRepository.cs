namespace MechaSync.Domain.Interface;

public interface IAvaliacaoRepository
{
    Avaliacao ObterPorId(int id);
    IEnumerable<Avaliacao> ListarPorUsuario(int usuarioId);
    void Adicionar(Avaliacao avaliacao);
    void Atualizar(Avaliacao avaliacao);
    void Remover(int id);
}