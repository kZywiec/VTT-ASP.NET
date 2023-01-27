namespace VTT.Models.Entities
{
    public class Item_Type : EntityBase
    {
        public string name { get; set; }
        public List<Item> items { get; set; }
    }
}
