using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace VTT.Models.Entities
{
    public class World : EntityBase
    {
        [Required]
        public string title;

        public string description;
        
        public DateTime nextSessionDate;


        //relationships
        public List<User_World_Character> Users_Worlds_Characters { get; set; }

    }
}
