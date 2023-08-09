namespace MechaSync.Domain.Interface;

public interface IUsuarioRepository
{
        Usuario ObterPorId(int id);
        IEnumerable<Usuario> ListarTodos();
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(int id);
}