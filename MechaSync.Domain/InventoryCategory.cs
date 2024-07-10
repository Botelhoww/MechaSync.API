namespace MechaSync.Domain
{
    public class InventoryCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<InventoryItemRelation> InventoryItemRelations { get; set; }
    }

}