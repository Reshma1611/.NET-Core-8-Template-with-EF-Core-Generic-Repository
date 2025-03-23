namespace Template.Web.Models
{
    public class Item : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PricePerUnit { get; set; }
        public int TotalUnit { get; set; }
        public int AvailaeUnit { get; set; }
    }
}
