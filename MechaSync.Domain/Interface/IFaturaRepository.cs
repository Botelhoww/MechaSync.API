namespace MechaSync.Domain.Interface;

public interface IFaturaRepository
{
    Fatura ObterPorId(int id);
    IEnumerable<Fatura> ListarPorUsuario(int usuarioId);
    void Adicionar(Fatura fatura);
    void Atualizar(Fatura fatura);
    void Remover(int id);
}