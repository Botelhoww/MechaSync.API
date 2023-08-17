namespace MechaSync.Domain.Interface;

public interface IAccountRepository
{
    Task AddAsync(Account usuario);
    Task<Account> GetByEmailAsync(string email);
}