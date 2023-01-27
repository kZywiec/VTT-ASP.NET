namespace VTT.Models.Entities
{
    public class User_World_Character
    {
        public int user_Id { get; set; }
        public User User { get; set; }
        public int world_Id { get; set; }
        public World World { get; set; }
        public int character_id { get; set; }
        public Character Character { get; set; }

    }
}

