using MechaSync.Domain;
using MechaSync.Domain.Dtos;
using MechaSync.Domain.Interface;
using MechaSync.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MechaSync.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly MechaSyncDbContext _context;

    public UserRepository(MechaSyncDbContext context)
    {
        _context = context;
    }

    public async Task InsertAsync(User user)
    {
        _context.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var teste = await _context.Users.Where(x => x.Email == email).SingleAsync();
        return teste;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.Where(x => x.Id == id).SingleAsync();
    }

    public IEnumerable<User> GetAllAsync()
    {
        return _context.Users.ToList().OrderByDescending(x => x.Id);
    }

    public async Task UpdateAsync(UserDto usuario)
    {
        _context.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var usuario = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (usuario == null)
            throw new Exception($"Usuário com ID {id} não encontrado");

        _context.Remove(usuario);
        await _context.SaveChangesAsync();
    }
}