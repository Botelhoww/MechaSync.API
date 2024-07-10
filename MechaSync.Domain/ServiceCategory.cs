namespace MechaSync.Domain
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ServiceCategoryRelation> ServiceCategoryRelations { get; set; }
    }
}