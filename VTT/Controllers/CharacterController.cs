using VTT.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;
using System.Collections;
using Microsoft.VisualBasic.FileIO;
using System.Linq;

namespace VTT.Controllers
{
    public class CharacterController : Controller
    {
        public static List<Character> characters = new List<Character> {
            new Character()
            {
                ID = 1, 
                Name = "Geralt",
                Sex = "Male",
                Age=112, 
                Race = "Witcher" 
            },

            new Character()
            {
                ID = 2, 
                Name = "Yennefer",
                Sex = "Female",
                Age=85,
                Race = "Human"
            },

            new Character()
            {
                ID = 3, 
                Name = "Zoltan Chivay",
                Sex = "Male",
                Age=62,
                Race = "Dwarf"
            }
        };

        static int Counter = 3;
        public IActionResult List()
        {
            return View(characters);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCharacter(Character character)
        {
            Counter++;
            character.ID = Counter;
            characters.Add(character);
            return View("List", characters);
        }

        [HttpPost]
        public IActionResult EditForm(Character character)
        {
            if (ModelState.IsValid)
            {
                characters[character.ID-1] = character;
                return View("List", characters);
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult EditForm(int id)
        {
            Character character = characters.Single(character => character.ID == id);
            return View(character);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Character character = characters.Single(character => character.ID == id);
            characters.Remove(character);
            return View("List", characters);
        }
    }
}
