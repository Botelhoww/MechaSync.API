namespace MechaSync.Domain;

public class Avaliacao
{
    public int AvaliacaoId { get; set; }
    public int UsuarioId { get; set; }
    public int Classificacao { get; set; } // Valores entre 1 e 5
    public string? Comentario { get; set; }
    public DateTime DataPublicacao { get; set; } = DateTime.Now;
}