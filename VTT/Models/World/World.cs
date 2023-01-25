namespace VTT.Models.World
{
    public class World
    {
        // ---|*|ATTRIBIUTES|*|---
        private int id;
        private string title;
        private DateTime nextSessionDate;
        private string description;

        // ---|*|PROPERTIES|*|---
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public DateTime NextSessionDate { get => nextSessionDate; set => nextSessionDate = value; }
        public string Description { get => description; set => description = value; }
    }
}
