using FluentValidation;
using MechaSync.Domain;
using MechaSync.Domain.Dtos;
using MechaSync.Domain.Interface;
using MechaSync.Domain.Requests;
using MechaSync.Services.Interfaces;
using MechaSync.Services.Services;

namespace MechaSync.Services;

public class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IValidator<RegisterRequest> _registerValidator;
    private readonly IValidator<LoginRequest> _loginValidator;

    public AccountService(IUserRepository userRepository,
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
            Name = registerRequest.Name,
            HashedPassword = passwordHash,
            Email = registerRequest.Email,
            Role = registerRequest.Role,
            CreatedDate = DateTime.Now
        };

        await _userRepository.InsertAsync(user);

        var jwt = "tokenzadaRegister";

        return new UserDto
        {
            Name = registerRequest.Name,
            Email = registerRequest.Email,
            Token = jwt
        };
    }

    public async Task<AccountDto> LoginAsync(LoginRequest loginRequest)
    {
        LoginService.IsValid(loginRequest, _loginValidator);

        User user = await _userRepository.GetByEmailAsync(loginRequest.Email);

        var result = _passwordHasherService.VerifyPassword(user.HashedPassword, loginRequest.Password);

        if (!result)
            throw new Exception("Email ou password incorreto!");

        var jwt = "tokenzadaLogin";

        return new AccountDto
        {
            Nome = user.Name,
            Token = jwt
        };
    }
}