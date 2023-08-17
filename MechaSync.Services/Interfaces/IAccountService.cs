using MechaSync.Domain.Dtos;
using MechaSync.Domain.Requests;

namespace MechaSync.Services.Interfaces;

public interface IAccountService
{
    public Task<UserDto> RegisterAsync(RegisterRequest registerRequest);
    public Task<AccountDto> LoginAsync(LoginRequest loginRequest);
}