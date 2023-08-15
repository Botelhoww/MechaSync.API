using MechaSync.Services.Interfaces;
using System.Security.Cryptography;

namespace MechaSync.Services.Services
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private const int SaltSize = 128 / 8;
        private const int KeySize = 256 / 8;
        private const int Iterations = 1000;
        private const char Delimiter = ';';

        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;

        public string Hash(string senha)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(senha, salt, Iterations, _hashAlgorithmName, KeySize);

            return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public bool VerificaSenha(string senhaHash, string inputSenha)
        {
            var elements = senhaHash.Split(Delimiter);
            var salt = Convert.FromBase64String(elements[0]);
            var hash = Convert.FromBase64String(elements[1]);

            var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputSenha, salt, Iterations, _hashAlgorithmName, KeySize);

            return CryptographicOperations.FixedTimeEquals(hash, hashInput);
        }
    }
}
