namespace MechaSync.Domain.Interface;

public interface IUsuarioRepository
{
    Task AddAsync(Usuario usuario);
    Task<Usuario> GetByEmailAsync(string email);

    //Task<Usuario> ObterPorId(int id);
    //IEnumerable<Usuario> ListarTodos();
    //Task Atualizar(Usuario usuario);
    //Task Remover(int id);
}