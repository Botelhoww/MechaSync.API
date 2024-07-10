namespace MechaSync.Domain
{
    /// <summary>
    /// Propósito: Armazenar informações adicionais do usuário, como nome completo e contato.
    /// Necessidade: Se você precisa de mais informações do usuário além do que está na tabela User, essa entidade é útil para separar dados pessoais de credenciais de login.
    /// </summary>
    public class UserProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Contact { get; set; }

        public User User { get; set; }
    }
}