namespace MechaSync.Domain
{
    public class InventoryItemRelation
    {
        public int InventoryItemId { get; set; }
        public int InventoryCategoryId { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public InventoryCategory InventoryCategory { get; set; }
    }

}