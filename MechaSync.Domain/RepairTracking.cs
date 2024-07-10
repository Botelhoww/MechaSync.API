namespace MechaSync.Domain
{
    public class RepairTracking
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Appointment Appointment { get; set; }
    }
}