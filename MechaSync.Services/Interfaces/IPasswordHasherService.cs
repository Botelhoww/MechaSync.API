namespace MechaSync.Services.Interfaces
{
    public interface IPasswordHasherService
    {
        string Hash(string password);

        bool VerifyPassword(string passwordHash, string inputPassword);
    }
}
