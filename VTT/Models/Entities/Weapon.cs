using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

using System. Buffers.Text;

namespace VTT.Models.Entities
{
    public class Weapon : Item
    {
        // ---|*|ATTRIBIUTES|*|---

      //private string ability;             //The ability the weapon is based on. </summary> 

        private bool isAmmo = false;        
        private bool useAmmo = false;        
        private bool throwable = false;     
        private bool isSlashing = false;    
        private bool isPiercing = false;     
        private bool isBludgeoning = false;  
        private bool isElemental = false;    

        private string damage = "";          
        private string effect = "";          

        private int accuracy;               
        private int reliability;            
        private int maxReliability;         
        private int hands;                   
        private int range;                   
        private int enhancements;

        public Weapon(Character_Item character_Item, Item_Type type, int type_id, int quantity, float weight, float cost, Item_Availability availability, int availability_id, Item_Concealmen concealmen, int concealment_id, string description) : base(character_Item, type, type_id, quantity, weight, cost, availability, availability_id, concealmen, concealment_id, description)
        {
        }






        // ---|*|PROPERTIES|*|---

        ///<summary> 
        ///Describes whether this weapon is to be considered ammunition. 
        ///</summary>
        public bool IsAmmo { get => isAmmo; set => isAmmo = value; }

        ///<summary> 
        ///Describes whether this weapon uses ammunition. 
        ///</summary>
        public bool UseAmmo { get => useAmmo; set => useAmmo = value; }

        ///<summary> 
        ///Describes whether the weapon is throwable. 
        ///</summary> 
        public bool Throwable { get => throwable; set => throwable = value; }

        ///<summary> 
        ///Means this weapon deals slashing damage. 
        ///</summary> 
        public bool IsSlashing { get => isSlashing; set => isSlashing = value; }

        ///<summary> 
        ///Means this weapon deals piercing damage. 
        ///</summary>
        public bool IsPiercing { get => isPiercing; set => isPiercing = value; }

        ///<summary> 
        ///Means this weapon deals bludgeoning damage. 
        ///</summary>
        public bool IsBludgeoning { get => isBludgeoning; set => isBludgeoning = value; }

        ///<summary> 
        ///Means this weapon deals elemental damage. 
        ///</summary>
        public bool IsElemental { get => isElemental; set => isElemental = value; }

        ///<summary> 
        ///Damage describes the severity of wound a weapon inflicts when it strikes a target. 
        ///</summary>
        public string Damage { get => damage; set => damage = value; }

        ///<summary> 
        ///Effect describes any extra abilities that this weapon can bring to bear. 
        ///</summary>
        public string Effect { get => effect; set => effect = value; }

        ///<summary> 
        ///Weapon Accuracy describes how well-balanced a weapon is. When attacking, add Accuracy to the attack. 
        ///</summary> 
        public int Accuracy { get => accuracy; set => accuracy = value; }

        ///<summary> 
        ///Reliability describes how sturdy the weapon is now. 
        ///</summary> 
        public int Reliability { get => reliability; set => reliability = value; }

        ///<summary> 
        ///This shows the number of times the weapon can be used to block before it breaks. 
        ///</summary> 
        public int MaxReliability { get => maxReliability; set => maxReliability = value; }

        ///<summary> 
        ///Hands Required describes how many hands you must have free to wield the weapon. 
        ///</summary>
        public int Hands { get => hands; set => hands = value; }

        ///<summary> 
        ///Range describes the farthest distance that you can strike an opponent from. 
        ///</summary>
        public int Range { get => range; set => range = value; }

        ///<summary> 
        ///Enhancements shows how many slots a weapon has for runes. 
        ///</summary> 
        public int Enhancements { get => enhancements; set => enhancements = value; }



        // ---|*|CONSTRUCTORS|*|---

        //public Weapon(int id, int quantity, float weight, float cost, int availability, int concealment, string description) 
        //    : base(id, "Weapon", quantity, weight, cost, availability, concealment, description)
        //{

        //}
    }
}
