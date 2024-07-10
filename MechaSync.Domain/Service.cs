namespace MechaSync.Domain
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }  // Foreign Key to User
        public User User { get; set; }

        //public ICollection<Review> Reviews { get; set; }
        //public ICollection<Appointment> Appointments { get; set; }
    }
}