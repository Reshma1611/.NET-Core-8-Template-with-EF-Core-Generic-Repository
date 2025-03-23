using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Template.Web.Models
{
    public class Inventory : Entity
    {
        public int UserId { get; set; } = 1;
        public User User { get; set; }

        public int Itemid { get; set; }
        public Item Item { get; set; }
        [DisplayName("Item")]
        public List<Item> ItemList { get; set; } 

        public int PricePerUnit { get; set; }
        public int TotalUnit { get; set; }

        public int TotalPrice { get; set; }
        public DateTime InventoryCreatedDate { get; set; } = DateTime.Now;
        public DateTime InventoryDueDate { get; set; } = DateTime.Now;
    }
}
