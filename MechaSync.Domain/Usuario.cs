namespace MechaSync.Domain;

public class Usuario
{
    public Usuario(string nomeUsuario, string senha, string email, string funcao)
    {
        NomeUsuario = nomeUsuario;
        Senha = senha;
        Email = email;
        Funcao = "Mecânico";
    }

    public int Id { get; set; }
    public string NomeUsuario { get; set; }
    public string Senha { get; set; } // Lembre-se de armazenar hashes, não senhas em texto claro!
    public string Email { get; set; }
    public string Funcao { get; set; }
}