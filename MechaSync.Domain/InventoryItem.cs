namespace MechaSync.Domain
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public ICollection<InventoryItemRelation> InventoryItemRelations { get; set; }
    }

}