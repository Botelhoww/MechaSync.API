namespace MechaSync.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Service Service { get; set; }
        public User User { get; set; }
    }
}