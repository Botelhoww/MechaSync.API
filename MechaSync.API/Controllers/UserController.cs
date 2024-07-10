using FluentValidation;
using MechaSync.Domain;
using MechaSync.Domain.Dtos;
using MechaSync.Domain.Requests;
using MechaSync.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MechaSync.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService usuarioService)
    {
        _userService = usuarioService;
    }

    [HttpPost("RegisterAsync")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest registerRequest)
    {
        try
        {
            await _userService.RegisterAsync(registerRequest);

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
            await _userService.LoginAsync(loginRequest);

            return Ok("User logged in!");
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

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Ok(_userService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = _userService.GetByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(UserDto user)
    {
        _userService.UpdateAsync(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult<User> DeleteUser(int id)
    {
        var user = _userService.GetByIdAsync(id);

        if (user == null)
            return NotFound();

        _userService.Delete(id);
        return Ok();
    }
}