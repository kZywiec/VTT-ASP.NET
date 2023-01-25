namespace VTT.Models
{
    public abstract class Items
    {
        // ---|*|ATTRIBIUTES|*|---

        private int id;               
        private string type;          
        private int quantity;         
        private float weight;         
        private float cost;           
        private string availability;  
        private string concealment;   
        private string description;   




        // ---|*|PROPERTIES|*|---

        ///<summary> Database Identifier. </summary>
        protected int Id { get => id; set => id = value; }

        ///<summary> Helps to manage items. </summary>
        protected string Type { get => type; set => type = value; }

        ///<summary> Describes how many items character chawe in inventory. </summary>
        protected int Quantity { get => quantity; set => quantity = value; }

        ///<summary> Describes how much the holder of this item will be additionary burdened. </summary>
        protected float Weight { get => weight; set => weight = value; }

        ///<summary> Value of item in in-game money. </summary>
        protected float Cost { get => cost; set => cost = value; }

        ///<summary> Availability describes how easy it is to find a item in shops or how often should be encountered in combat. </summary>
        protected string Availability { get => availability; set => availability = value; }

        ///<summary> Concealment describes where you can hide a item. </summary>
        protected string Concealment { get => concealment; set => concealment = value; }

        ///<summary> It stores a description of the appearance, use or history of the item. </summary>
        protected string Description { get => description; set => description = value; }



        // ---|*|CONSTRUCTORS|*|---

        protected Items(int id, string type, int quantity, float weight, float cost, string availability, string concealment, string description)
        {
            this.Id = id;
            this.Type = type;
            this.Quantity = quantity;
            this.Weight = weight;
            this.Cost = cost;
            this.Availability = availability;
            this.Concealment = concealment;
            this.Description = description;
        }
    }
}
