namespace MechaSync.Domain;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string HashedPassword { get; set; }
    public string? Role { get; set; }
    public DateTime CreatedDate { get; set; }
}