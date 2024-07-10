namespace MechaSync.Domain;

public class User
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<Address> Addresses { get; set; }
    public ICollection<PaymentMethod> PaymentMethods { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    public ICollection<Contact> Contacts { get; set; }
}