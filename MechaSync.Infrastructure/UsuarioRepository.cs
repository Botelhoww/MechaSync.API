using MechaSync.Domain;
using MechaSync.Domain.Interface;
using MechaSync.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MechaSync.Infrastructure;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly MechaSyncDbContext _context;

    public UsuarioRepository(MechaSyncDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Usuario usuario)
    {
        _context.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<Usuario> GetByEmailAsync(string email)
    {
        return await _context.Usuarios.Where(x => x.Email == email).SingleAsync();
    }

    //public async Task<Usuario> ObterPorId(int id)
    //{
    //    return await _context.Usuarios.Where(x => x.Id == id).SingleAsync();
    //}

    //public IEnumerable<Usuario> ListarTodos()
    //{
    //    return _context.Usuarios.ToList().OrderByDescending(x => x.Id);
    //}

    //public async Task Atualizar(Usuario usuario)
    //{
    //    _context.Update(usuario);
    //    await _context.SaveChangesAsync();
    //}

    //public async Task Remover(int id)
    //{
    //    var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

    //    if (usuario == null)
    //        throw new Exception($"Usuário com ID {id} não encontrado");

    //    _context.Remove(usuario);
    //    await _context.SaveChangesAsync();
    //}
}