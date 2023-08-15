using MechaSync.Domain;
using MechaSync.Domain.DTOs;

namespace MechaSync.Services.Interfaces;

public interface IUsuarioService
{
    public Task<UsuarioDTO> RegisterAsync(Usuario usuario);



    //public Task Remover(int id);
    //public Task Atualizar(Usuario usuario);
    //public IEnumerable<Usuario> ListarTodos();
    //public Task<Usuario> ObterPorId(int id);
}