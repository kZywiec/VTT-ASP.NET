using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace VTT.Models
{
    public class Character
    {
        public DateTime CreatedDate { get; set; }

        private int id;

        //Basic informations
        private string name ="";
        private string sex = "";
        private int age = 0;
        private string race = "";
        private string social_standing = "";
        private string homeland = "";

        //Statistics
        private int intelligence = 0;
        private int reflexes = 0;
        private int dexterity = 0;
        private int body = 0;
        private int speed = 0;
        private int emphaty = 0;
        private int craft = 0;
        private int will = 0;
        private int luck = 0;

        [HiddenInput]
        public int ID { get => id; set => id = value; }
        [Required(ErrorMessage = "Please put the name")]
        public string Name { get => name; set => name = value; }
        public string Sex { get => sex; set => sex = value; }
        public int Age { get => age; set => age = value; }
        public string Race { get => race; set => race = value; }
        public string Social_Standing { get => social_standing; set => social_standing = value; }
        public string Homeland { get => homeland; set => homeland = value; }



        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Reflexes { get => reflexes; set => reflexes = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Body { get => body; set => body = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Emphaty { get => emphaty; set => emphaty = value; }
        public int Craft { get => craft; set => craft = value; }
        public int Will { get => will; set => will = value; }
        public int Luck { get => luck; set => luck = value; }

        public int Id => id;

        public Character() { }
        public Character(int id) { this.id = id; }

        public int Run()
            => Speed * 3;
        public int Leap()
            => (Speed * 3) % 5;
        public int Stun()
            => ((Body + Will) / 2) * 10;
        //Health Points
        public int HP()
            => ((Body + Will) / 2) * 5;
        //Stamina
        public int STA()
            => HP();
        //Recovery
        public int REC()
            => (Body + Will) / 2;
        //Encumbrance
        public int ENC()
            => Stun();
    }
}
