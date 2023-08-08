namespace MechaSync.Domain;

public class Usuario
{
    public int UsuarioID { get; set; }
    public string NomeUsuario { get; set; }
    public string Senha { get; set; } // Lembre-se de armazenar hashes, não senhas em texto claro!
    public string Email { get; set; }
    public string Funcao { get; set; } = "Mecanico";
}