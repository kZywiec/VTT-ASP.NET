using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;

namespace VTT.Models.Entities
{
    public class Item_Availability : EntityBase
    {
        [Required]
        public string name { get; set; }

        [ValidateNever]
        public List<Item> items { get; set; }

    }
}
