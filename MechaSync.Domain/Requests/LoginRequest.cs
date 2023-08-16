namespace MechaSync.Domain.Requests
{
    public class LoginRequest
    {
        public LoginRequest(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
