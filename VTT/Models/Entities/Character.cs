using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VTT.Models.Entities
{
    public class Character : EntityBase
    {
        // ---|*|ATTRIBIUTES|*|---

        //Basic informations
        public string name = "";
        public string sex = "";
        public int age = 0;
        public string race = "";
        public string social_standing = "";
        public string homeland = "";


        // Characteristics
        public int intelligence = 0;
        public int reflexes = 0;
        public int dexterity = 0;
        public int body = 0;
        public int speed = 0;
        public int emphaty = 0;
        public int craft = 0;
        public int will = 0;
        public int luck = 0;

        // Statistics
        public int hp = 0;
        public int run = 0;
        public int leap = 0;
        public int stun = 0;
        public int stamina = 0;
        public int recovery = 0;
        public int encumbrance = 0;

        // ---|*|Relationships|*|---

        public List<User_World_Character> Users_Worlds_Characters;
        public List<Character_Item> Character_Items;

        // ---|*|CONSTRUCTORS|*|---
        public Character(int id)
        {
            this.id = id;
            CalculateStats();
        }



        public void CalculateStats()
        {
            hp = (body + will) / 2 * 5;
            run = speed * 3;
            leap = speed * 3 / 5;
            recovery = (body + will) / 2;
            stun = (body + will) / 2 * 10;
            encumbrance = (body + will) / 2 * 10;
        }
    }
}
