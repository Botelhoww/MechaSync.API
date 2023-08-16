namespace MechaSync.Domain.Requests
{
    public class RegisterRequest
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Funcao { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
