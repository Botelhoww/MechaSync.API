namespace MechaSync.Domain.Interface;

public interface IPecaRepository
{
    Peca ObterPorId(int id);
    IEnumerable<Peca> ListarTodos();
    void Adicionar(Peca peca);
    void Atualizar(Peca peca);
    void Remover(int id);
}