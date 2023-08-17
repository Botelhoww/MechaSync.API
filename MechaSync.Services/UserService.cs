using MechaSync.Domain;
using MechaSync.Domain.Dtos;
using MechaSync.Domain.Interface;
using MechaSync.Services.Interfaces;
using MechaSync.Services.Services;

namespace MechaSync.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository usuarioRepository)
    {
        _userRepository = usuarioRepository;
    }

    public IEnumerable<User> GetAllAsync()
    {
        return _userRepository.GetAllAsync();
    }

    public Task<User> GetByIdAsync(int id)
    {
        return _userRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(UserDto usuario)
    {
        if (EmailService.IsValid(usuario.Email))
            await _userRepository.UpdateAsync(usuario);
        else
            throw new Exception($"Email {usuario.Email} não é válido!");
    }

    public Task Delete(int id)
    {
        return _userRepository.Delete(id);
    }
}