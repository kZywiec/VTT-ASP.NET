namespace VTT.Models.Entities
{
    public class User_World : EntityBase
    {
        public int user_id { get; set; }
        public User User { get; set; }
        public int world_id { get; set; }
        public World World { get; set; }
        public List<Character> Characters { get; set; } = new();
    }
}

