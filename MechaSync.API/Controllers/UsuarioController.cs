using FluentValidation;
using MechaSync.Domain;
using MechaSync.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MechaSync.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService, IPasswordHasherService passwordHasherService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync(Usuario usuario)
    {
        try
        {
            if (!ModelState.IsValid)
                throw new Exception("Model is not valid");

            await _usuarioService.RegisterAsync(usuario);

            return CreatedAtAction("ListarTodos", usuario);
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