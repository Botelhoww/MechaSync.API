namespace MechaSync.Services.Interfaces
{
    public interface IPasswordHasherService
    {
        string Hash(string senha);

        bool VerificaSenha(string senhaHash, string inputSenha);
    }
}
