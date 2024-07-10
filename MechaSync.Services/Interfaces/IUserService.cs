using MechaSync.Domain;
using MechaSync.Domain.Dtos;
using MechaSync.Domain.Requests;

namespace MechaSync.Services.Interfaces;

public interface IUserService
{
    public Task<UserDto> RegisterAsync(RegisterRequest registerRequest);
    public Task<UserDto> LoginAsync(LoginRequest loginRequest);

    public Task<User> GetByIdAsync(int id);
    public Task<IEnumerable<User>> GetAllAsync();

    public Task UpdateAsync(UserDto usuario);
    public Task Delete(int id);
}