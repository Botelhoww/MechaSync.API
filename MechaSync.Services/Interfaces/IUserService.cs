using MechaSync.Domain;
using MechaSync.Domain.Dtos;

namespace MechaSync.Services.Interfaces;

public interface IUserService
{
    public Task<User> GetByIdAsync(int id);
    public IEnumerable<User> GetAllAsync();

    public Task UpdateAsync(UserDto usuario);
    public Task Delete(int id);
}