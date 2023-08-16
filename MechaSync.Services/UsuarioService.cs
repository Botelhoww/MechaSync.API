using FluentValidation;
using MechaSync.Domain;
using MechaSync.Domain.DTOs;
using MechaSync.Domain.Interface;
using MechaSync.Domain.Requests;
using MechaSync.Services.Interfaces;
using MechaSync.Services.Services;

namespace MechaSync.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IValidator<RegisterRequest> _registerValidator;
    private readonly IValidator<LoginRequest> _loginValidator;

    public UsuarioService(IUsuarioRepository usuarioRepository,
        IPasswordHasherService passwordHasherService,
        IValidator<RegisterRequest> registerValidator,
        IValidator<LoginRequest> loginValidator)
    {
        _usuarioRepository = usuarioRepository;
        _passwordHasherService = passwordHasherService;
        _registerValidator = registerValidator;
        _loginValidator = loginValidator;
    }

    public async Task<UsuarioDTO> RegisterAsync(RegisterRequest registerRequest)
    {
        RegisterService.IsValid(registerRequest, _registerValidator);

        var passwordHash = _passwordHasherService.Hash(registerRequest.Senha);

        var user = new Usuario
        {
            Nome = registerRequest.Nome,
            Senha = passwordHash,
            Email = registerRequest.Email,
            Funcao = registerRequest.Funcao,
            CreatedDate = DateTime.Now
        };

        await _usuarioRepository.AddAsync(user);

        var jwt = "tokenzadaRegister";

        return new UsuarioDTO
        {
            Nome = registerRequest.Nome,
            Token = jwt
        };
    }

    public async Task<UsuarioDTO> LoginAsync(LoginRequest loginRequest)
    {
        LoginService.IsValid(loginRequest, _loginValidator);

        var user = await _usuarioRepository.GetByEmailAsync(loginRequest.Email);

        var result = _passwordHasherService.VerificaSenha(user.Senha, loginRequest.Senha);

        if (!result)
            throw new Exception("Senha ou Email Incorreto!");

        var jwt = "tokenzadaLogin";

        return new UsuarioDTO
        {
            Nome = user.Nome,
            Token = jwt
        };
    }

    //public IEnumerable<Usuario> ListarTodos()
    //{
    //    return _usuarioRepository.ListarTodos();
    //}

    //public Task<Usuario> ObterPorId(int id)
    //{
    //    return _usuarioRepository.ObterPorId(id);
    //}

    //public async Task Atualizar(Usuario usuario)
    //{
    //    if (EmailService.IsValid(usuario.Email))
    //        await _usuarioRepository.Atualizar(usuario);
    //    else
    //        throw new Exception($"Email {usuario.Email} não é válido!");
    //}

    //public Task Remover(int id)
    //{
    //    return _usuarioRepository.Remover(id);
    //}
}