using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;
using System.Collections;
using Microsoft.VisualBasic.FileIO;
using System.Linq;
using VTT.Models.Entities;

namespace VTT.Controllers
{
    public class CharacterController : Controller
    {
        public static List<Character> characters = new List<Character> {
            new Character(1)
            {
                name = "Geralt",
                sex = "Male",
                age=112, 
                race = "Witcher" 
            },

            new Character(2)
            { 
                name = "Yennefer",
                sex = "Female",
                age=85,
                race = "Human"
            },

            new Character(3)
            {
                name = "Zoltan Chivay",
                sex = "Male",
                age=62,
                race = "Dwarf"
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
            character.id = Counter;
            characters.Add(character);
            return View("List", characters);
        }

        [HttpPost]
        public IActionResult EditForm(Character character)
        {
            if (ModelState.IsValid)
            {
                characters[character.id-1] = character;
                return View("List", characters);
            }
            else
                return View();
        }

        [HttpGet]
        public IActionResult EditForm(int id)
        {
            Character character = characters.Single(character => character.id == id);
            return View(character);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Character character = characters.Single(character => character.id == id);
            characters.Remove(character);
            return View("List", characters);
        }
    }
}
