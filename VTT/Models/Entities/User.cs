using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VTT.Models.Entities
{
    public class User : EntityBase
    {
        [Required]
        [StringLength(20, ErrorMessage = "Login Can't be longer than 20 character.")]
        public string login { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Password length must be between {2} and {1}.", MinimumLength = 5)]
        public string password { get; set; }

        [HiddenInput]
        public bool isAdmin { get; set; }

        //relationships
        [ValidateNever]
        public List<User_World> Users_Worlds_Characters { get; set; }

        public User()
        {
            Users_Worlds_Characters = new List<User_World>();
        }
    }
}