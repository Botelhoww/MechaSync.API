using FluentValidation;
using MechaSync.Domain.Requests;
using MechaSync.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MechaSync.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService usuarioService)
    {
        _accountService = usuarioService;
    }

    [HttpPost("RegisterAsync")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest registerRequest)
    {
        try
        {
            await _accountService.RegisterAsync(registerRequest);

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
            await _accountService.LoginAsync(loginRequest);

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