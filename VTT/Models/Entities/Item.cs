using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace VTT.Models.Entities
{
    public class Item : EntityBase
    {
        public Item(int type_id, int quantity, float weight, float cost, int availability_id, int concealment_id, string description)
        {
            this.type_id = type_id;
            this.quantity = quantity;
            this.weight = weight;
            this.cost = cost;
            this.availability_id = availability_id;
            this.concealment_id = concealment_id;
            this.description = description;
        }

        public Item(Character_Item character_Item, Item_Type type, int type_id, int quantity, float weight, float cost, Item_Availability availability, int availability_id, Item_Concealmen concealmen, int concealment_id, string description)
        {
            Character_Item = character_Item;
            this.type = type;
            this.type_id = type_id;
            this.quantity = quantity;
            this.weight = weight;
            this.cost = cost;
            this.availability = availability;
            this.availability_id = availability_id;
            this.concealmen = concealmen;
            this.concealment_id = concealment_id;
            this.description = description;
        }



        // ---|*|ATTRIBIUTES|*|---
        public Character_Item Character_Item {get; set;}


        ///<summary> 
        ///Helps to manage items. 
        ///</summary>
        public Item_Type type { get; set; }
        public int type_id { get; set; }

        ///<summary> 
        ///Describes how many items character chawe in inventory. 
        ///</summary>
        public int quantity { get; set; }

        ///<summary> 
        ///Describes how much the holder of this item will be additionary burdened. 
        ///</summary>
        public float weight {get; set;}

        ///<summary> 
        ///Value of item in in-game money. 
        ///</summary>
        public float cost { get; set; }

        ///<summary> 
        ///Availability describes how easy it is to find a item in shops or how often should be encountered in combat. 
        ///</summary>
        public Item_Availability availability { get; set; }
        public int availability_id { get; set; }

        ///<summary> 
        ///Concealment describes where you can hide a item. 
        ///</summary>
        public Item_Concealmen concealmen { get; set; }
        public int concealment_id { get; set; }

        ///<summary> 
        ///It stores a description of the appearance, use or history of the item. 
        ///</summary>
        public string description { get; set; }



        // ---|*|CONSTRUCTORS|*|---

    }
}
