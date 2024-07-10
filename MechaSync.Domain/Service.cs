namespace MechaSync.Domain
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<ServiceCategoryRelation> ServiceCategoryRelations { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}