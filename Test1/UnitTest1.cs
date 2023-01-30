using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using VTT.Models.Entities;

namespace Test1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void CalculateStats()
        {
            Character character = new();

            character.intelligence = 10;
            character.reflex = 10;
            character.dexterity = 10;
            character.body = 10;
            character.speed = 10;
            character.empathy = 10;
            character.craft = 10;
            character.will = 10;
            character.luck = 10;

            character.CalculateStats();


            Assert.IsTrue(character.hp == 50 && character.run == 30 && character.leap == 6 && character.recovery == 10 && character.stun == 100 && character.encumbrance == 100);
        }
    }
}
