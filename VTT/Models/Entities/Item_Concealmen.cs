namespace VTT.Models.Entities
{
    public class Item_Concealmen :EntityBase
    {
        public string name { get; set; }
        public List<Item> items { get; set; }
    }
}
