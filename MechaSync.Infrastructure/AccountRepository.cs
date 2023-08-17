using MechaSync.Domain;
using MechaSync.Domain.Interface;
using MechaSync.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MechaSync.Infrastructure;

public class AccountRepository : IAccountRepository
{
    private readonly MechaSyncDbContext _context;

    public AccountRepository(MechaSyncDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Account usuario)
    {
        _context.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<Account> GetByEmailAsync(string email)
    {
        return await _context.Accounts.Where(x => x.Email == email).SingleAsync();
    }
}