namespace Template.Web.Models
{
    public class Payment : Entity
    {
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int TotalPrice { get; set; }
        public int Paid { get; set; }
    }
}
