using MechaSync.Domain;
using MechaSync.Domain.DTOs;
using MechaSync.Domain.Interface;
using MechaSync.Services.Interfaces;
using MechaSync.Services.Services;

namespace MechaSync.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasherService _passwordHasherService;

    public UsuarioService(IUsuarioRepository usuarioRepository, IPasswordHasherService passwordHasherService)
    {
        _usuarioRepository = usuarioRepository;
        _passwordHasherService = passwordHasherService;

    }

    public async Task<UsuarioDTO> RegisterAsync(Usuario usuario)
    {
        if (!EmailService.IsValid(usuario.Email))
            throw new Exception($"Email ({usuario.Email}) não é válido!");

        var passwordHash = _passwordHasherService.Hash(usuario.Senha);

        var user = new Usuario
        {
            Nome = usuario.Nome,
            Senha = passwordHash,
            Email = usuario.Email,
            Funcao = usuario.Funcao
        };

        await _usuarioRepository.AddAsync(user);

        var jwt = "tokenzadaRegister";

        return new UsuarioDTO
        {
            Nome = usuario.Nome,
            Token = jwt
        };
    }

    public async Task<UsuarioDTO> LoginAsync(UsuarioDTO usuarioDto)
    {
        var user = await _usuarioRepository.GetByEmailAsync(usuarioDto.Email);

        var result = _passwordHasherService.VerificaSenha(user.Senha, usuarioDto.Senha);

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