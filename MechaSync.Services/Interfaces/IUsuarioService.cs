using MechaSync.Domain.DTOs;
using MechaSync.Domain.Requests;

namespace MechaSync.Services.Interfaces;

public interface IUsuarioService
{
    public Task<UsuarioDTO> RegisterAsync(RegisterRequest registerRequest);
    public Task<UsuarioDTO> LoginAsync(LoginRequest loginRequest);
}