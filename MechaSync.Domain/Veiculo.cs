namespace MechaSync.Domain;

public class Veiculo
{
    public Veiculo(int usuarioId, string placa, string modelo, string marca, int ano)
    {
        UsuarioId = usuarioId;
        Placa = placa;
        Modelo = modelo;
        Marca = marca;
        Ano = ano;
    }

    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public int Ano { get; set; }
}