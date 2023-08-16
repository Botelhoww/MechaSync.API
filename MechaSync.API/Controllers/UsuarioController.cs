using FluentValidation;
using MechaSync.Domain.Requests;
using MechaSync.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MechaSync.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("RegisterAsync")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest registerRequest)
    {
        try
        {
            await _usuarioService.RegisterAsync(registerRequest);

            return Created("RegisterAsync", registerRequest);
        }
        catch (ValidationException e)
        {
            throw new ValidationException(e.Errors);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpPost("LoginAsync")]
    public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
    {
        try
        {
            await _usuarioService.LoginAsync(loginRequest);

            return Ok("Usuário logado!");
        }
        catch (ValidationException e)
        {
            throw new ValidationException(e.Errors);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}