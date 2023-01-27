using System.ComponentModel.DataAnnotations.Schema;

namespace VTT.Models.Entities
{
    public class Character_Item : EntityBase
    {
        public int character_id { get; set; }
        [ForeignKey("character_id")]
        public Character Character { get; set; }

        public int item_id { get; set; }
        [ForeignKey("item_id")]
        public Item Item { get; set; }
    }
}

