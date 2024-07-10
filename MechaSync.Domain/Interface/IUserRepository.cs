using MechaSync.Domain.Dtos;

namespace MechaSync.Domain.Interface;

public interface IUserRepository
{
    Task AddAsync(User usuario);

    Task InsertAsync(User usuario);
    Task<User> GetByEmailAsync(string email);
    Task<User> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task UpdateAsync(UserDto usuario);
    Task Delete(int id);
}