namespace MechaSync.Domain.Interface;

public interface IVeiculoRepository
{
    Veiculo ObterPorId(int id);
    IEnumerable<Veiculo> ListarPorUsuario(int usuarioId);
    void Adicionar(Veiculo veiculo);
    void Atualizar(Veiculo veiculo);
    void Remover(int id);
}