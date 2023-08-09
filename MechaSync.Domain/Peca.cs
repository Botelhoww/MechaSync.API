namespace MechaSync.Domain;

public class Peca
{
    public Peca(string nome, string descricao, int quantidade, decimal preco)
    {
        Nome = nome;
        Descricao = descricao;
        Quantidade = quantidade;
        Preco = preco;
    }

    public int PecaId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
}