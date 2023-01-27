using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VTT.Models.Entities
{
    public class User : EntityBase
    {
        public string role;

        public string login;

        public string password;

        //relationships
        public List<User_World_Character> Users_Worlds_Characters;
    }
}
