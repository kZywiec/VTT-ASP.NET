using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VTT.Models.Entities
{
    public class Item : EntityBase
    {
        // ---|*|ATTRIBIUTES|*|---

        ///<summary> 
        ///Name of the item. 
        ///</summary>
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }


        ///<summary> 
        ///Helps to manage items. 
        ///</summary>
        [Display(Name = "Type ID")]
        [Required(ErrorMessage = "Type ID is required.")]
        public int type_id { get; set; }

        [ValidateNever]
        public Item_Type type { get; set; }

        ///<summary> 
        ///Describes how many items character chawe in inventory. 
        ///</summary>
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required.")]
        public int quantity { get; set; }

        ///<summary> 
        ///Describes how much the holder of this item will be additionary burdened. 
        ///</summary>
        [Display(Name = "Weight")]
        [Required(ErrorMessage = "Weight is required.")]
        public float weight { get; set; }

        ///<summary> 
        ///Value of item in in-game money. 
        ///</summary>
        [Display(Name = "Cost")]
        [Required(ErrorMessage = "Cost is required.")]
        public int cost { get; set; }

        ///<summary> 
        ///Availability describes how easy it is to find a item in shops or how often should be encountered in combat. 
        ///</summary>
        [Display(Name = "Availability ID")]
        [Required(ErrorMessage = "Availability ID is required.")]
        public int availability_id { get; set; }

        [ValidateNever]
        public Item_Availability availability { get; set; }

        ///<summary> 
        ///Concealment describes where you can hide a item. 
        ///</summary>
        [Display(Name = "Concealment ID")]
        [Required(ErrorMessage = "Concealment ID is required.")]
        public int concealment_id { get; set; }

        [ValidateNever]
        public Item_Concealment concealment { get; set; }

        ///<summary> 
        ///It stores a description of the appearance, use or history of the item. 
        ///</summary>
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required.")]
        public string description { get; set; }

        [ValidateNever]
        public Character_Item Character_Item { get; set; }
    }
}
