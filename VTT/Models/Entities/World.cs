using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace VTT.Models.Entities
{
    public class World : EntityBase
    {
        [Required]
        [StringLength(30)]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime nextSessionDate { get; set; }

        //relationships
        [HiddenInput]
        public List<User_World> Users_Worlds { get; set; }

        public World()
        {
            Users_Worlds = new List<User_World>();
        }

    }
}
