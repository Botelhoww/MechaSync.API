namespace MechaSync.Domain;

public class Fatura
{
    public Fatura(int usuarioId, int veiculoId, decimal valorTotal, bool pago)
    {
        UsuarioId = usuarioId;
        VeiculoId = veiculoId;
        ValorTotal = valorTotal;
        Pago = pago;
    }

    public int FaturaId { get; set; }
    public int UsuarioId { get; set; }
    public int VeiculoId { get; set; }
    public decimal ValorTotal { get; set; }
    public bool Pago { get; set; } = false;
    public DateTime DataEmissao { get; set; } = DateTime.Now;
}