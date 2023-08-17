namespace MechaSync.Domain;

public class Account
{
    public int Id { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public DateTime CreatedDate { get; set; }
}