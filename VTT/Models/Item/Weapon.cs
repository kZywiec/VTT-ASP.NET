using System.Buffers.Text;

namespace VTT.Models.Item
{
    public class Weapon : Items
    {
        // ---|*|ATTRIBIUTES|*|---

      //private string ability;             //The ability the weapon is based on.

        private bool isAmmo = false;        //Describes whether this weapon is to be considered ammunition.
        private bool useAmmo = false;       //Describes whether this weapon uses ammunition.
        private bool throwable = false;     //Describes whether the weapon is throwable.
        private bool isSlashing = false;    //Means this weapon deals slashing damage.
        private bool isPiercing = false;    //Means this weapon deals piercing damage.
        private bool isBludgeoning = false; //Means this weapon deals bludgeoning damage.
        private bool isElemental = false;   //Means this weapon deals elemental damage

        private string damage = "";         //Damage describes the severity of wound a weapon inflicts when it strikes a target.
        private string effect = "";         //Effect describes any extra abilities that this weapon can bring to bear.

        private int accuracy;               //Weapon Accuracy describes how well-balanced a weapon is. When attacking, add Accuracy to the attack.
        private int reliability;            //Reliability describes how sturdy the weapon is now.
        private int maxReliability;         //This shows the number of times the weapon can be used to block before it breaks.
        private int hands;                  //Hands Required describes how many hands you must have free to wield the weapon.
        private int range;                  //Range describes the farthest distance that you can strike an opponent from.
        private int enhancements;           //Enhancements shows how many slots a weapon has for runes.



        // ---|*|PROPERTIES|*|---

        public bool IsAmmo { get => isAmmo; set => isAmmo = value; }
        public bool UseAmmo { get => useAmmo; set => useAmmo = value; }
        public bool Throwable { get => throwable; set => throwable = value; }
        public bool IsSlashing { get => isSlashing; set => isSlashing = value; }
        public bool IsPiercing { get => isPiercing; set => isPiercing = value; }
        public bool IsBludgeoning { get => isBludgeoning; set => isBludgeoning = value; }
        public bool IsElemental { get => isElemental; set => isElemental = value; }

        public string Damage { get => damage; set => damage = value; }
        public string Effect { get => effect; set => effect = value; }

        public int Accuracy { get => accuracy; set => accuracy = value; }
        public int Reliability { get => reliability; set => reliability = value; }
        public int MaxReliability { get => maxReliability; set => maxReliability = value; }
        public int Hands { get => hands; set => hands = value; }
        public int Range { get => range; set => range = value; }
        public int Enhancements { get => enhancements; set => enhancements = value; }



        // ---|*|CONSTRUCTORS|*|---

        public Weapon(int id, int quantity, float weight, float cost, string availability, string concealment, string description) : base(id, "Weapon", quantity, weight, cost, availability, concealment, description)
        {

        }


    }
}
