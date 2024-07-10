using FluentValidation;
using MechaSync.Domain;
using MechaSync.Domain.Dtos;
using MechaSync.Domain.Interface;
using MechaSync.Domain.Requests;
using MechaSync.Services.Interfaces;

namespace MechaSync.Services.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IValidator<RegisterRequest> _registerValidator;
    private readonly IValidator<LoginRequest> _loginValidator;

    public UserService(IUserRepository userRepository,
        IPasswordHasherService passwordHasherService,
        IValidator<RegisterRequest> registerValidator,
        IValidator<LoginRequest> loginValidator)
    {
        _userRepository = userRepository;
        _passwordHasherService = passwordHasherService;
        _registerValidator = registerValidator;
        _loginValidator = loginValidator;
    }

    public async Task<UserDto> RegisterAsync(RegisterRequest registerRequest)
    {
        RegisterService.IsValid(registerRequest, _registerValidator);

        var passwordHash = _passwordHasherService.Hash(registerRequest.Password);

        var user = new User
        {
            UserName = registerRequest.Name,
            PasswordHash = passwordHash,
            Email = registerRequest.Email,
            CreatedAt = DateTime.Now
        };

        await _userRepository.InsertAsync(user);

        //TODO: need to implement JWT auth.
        var jwt = "tokenzadaRegister";

        return new UserDto
        {
            Name = registerRequest.Name,
            Email = registerRequest.Email,
            Token = jwt
        };
    }

    public async Task<UserDto> LoginAsync(LoginRequest loginRequest)
    {
        LoginService.IsValid(loginRequest, _loginValidator);

        User user = await _userRepository.GetByEmailAsync(loginRequest.Email);

        var result = _passwordHasherService.VerifyPassword(user.PasswordHash, loginRequest.Password);

        if (!result)
            throw new Exception("Incorrect password or email!");

        //TODO: need to implement JWT auth.
        var jwt = "tokenzadaLogin";

        return new UserDto
        {
            Name = user.UserName,
            Token = jwt
        };
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(UserDto usuario)
    {
        if (EmailService.IsValid(usuario.Email))
            await _userRepository.UpdateAsync(usuario);
        else
            throw new Exception($"Email {usuario.Email} is not valid!");
    }

    public async Task Delete(int id)
    {
        await _userRepository.Delete(id);
    }
}