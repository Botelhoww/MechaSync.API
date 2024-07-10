namespace MechaSync.Domain
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }

        public User User { get; set; }
    }
}