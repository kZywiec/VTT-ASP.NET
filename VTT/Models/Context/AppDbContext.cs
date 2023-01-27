using Microsoft.EntityFrameworkCore;
using VTT.Models.Entities;


namespace VTT.Models.Context
{
    // Context - klasa konfiguracyjna EF Core
    public class AppDbContext : DbContext
    {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<World> Worlds { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<User_World_Character> Users_Worlds_Characters { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.id);
                entity.Property(u => u.login);
                entity.Property(u => u.password);
                entity.Property(u => u.role);

            });

            modelBuilder.Entity<World>(entity =>
            {
                entity.ToTable("Worlds");
                entity.HasKey(w => w.id);
                entity.Property(w => w.title);
                entity.Property(w => w.description);
                entity.Property(w => w.nextSessionDate);

            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("Characters");
                entity.HasKey(c => c.id);
                entity.Property(c => c.name);
                entity.Property(c => c.sex);
                entity.Property(c => c.age);
                entity.Property(c => c.race);
                entity.Property(c => c.social_standing);
                entity.Property(c => c.homeland);
                entity.Property(c => c.intelligence);
                entity.Property(c => c.reflexes);
                entity.Property(c => c.dexterity);
                entity.Property(c => c.body);
                entity.Property(c => c.speed);
                entity.Property(c => c.emphaty);
                entity.Property(c => c.craft);
                entity.Property(c => c.will);
                entity.Property(c => c.luck);
                entity.Property(c => c.hp);
                entity.Property(c => c.run);
                entity.Property(c => c.leap);
                entity.Property(c => c.stun);
                entity.Property(c => c.stamina);
                entity.Property(c => c.recovery);
                entity.Property(c => c.encumbrance);
            });

            modelBuilder.Entity<User_World_Character>().ToTable("Users_Worlds_Characters").HasKey(uwc => new
            {
                uwc.user_Id,
                uwc.world_Id,
                uwc.character_id
            });

            modelBuilder.Entity<Character_Item>().ToTable("Characters_Items").HasKey(ci => new
            {
                ci.character_id,
                ci.item_id
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Items");
                entity.HasKey(i => i.id);
                entity.Property(i => i.quantity);
                entity.Property(i => i.weight);
                entity.Property(i => i.cost);
                entity.Property(i => i.type_id);
                entity.Property(i => i.availability_id);
                entity.Property(i => i.concealment_id);
                entity.Property(i => i.description);
            });


            modelBuilder.Entity<Item_Availability>(entity =>
            {
                entity.ToTable("Items_Availabilitis");
                entity.HasKey(ia => ia.id);
                entity.Property(ia => ia.name);
            });

            modelBuilder.Entity<Item_Concealmen>(entity =>
            {
                entity.ToTable("Items_Concealmens");
                entity.HasKey(ic => ic.id);
                entity.Property(ic => ic.name);
            });

            modelBuilder.Entity<Item_Type>(entity =>
            {
                entity.ToTable("Items_Types");
                entity.HasKey(it => it.id);
                entity.Property(it => it.name);
            });


            modelBuilder.Entity<User_World_Character>()
                            .HasOne(u => u.User)
                            .WithMany(uwc => uwc.Users_Worlds_Characters)
                            .HasForeignKey(u => u.user_Id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User_World_Character>()
                            .HasOne(w => w.World)
                            .WithMany(uwc => uwc.Users_Worlds_Characters)
                            .HasForeignKey(w => w.world_Id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character>()
                            .HasMany(c => c.Users_Worlds_Characters)
                            .WithOne(uwc => uwc.Character)
                            .HasForeignKey(uwc => uwc.character_id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character_Item>()
                            .HasOne(c => c.Character)
                            .WithMany(ci => ci.Character_Items)
                            .HasForeignKey(c => c.character_id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character_Item>()
                            .HasOne(i => i.Item)
                            .WithOne(ci => ci.Character_Item)
                            .HasForeignKey<Character_Item>(ci => ci.item_id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                            .HasOne(i => i.availability)
                            .WithMany(ia => ia.items)
                            .HasForeignKey(i => i.availability_id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                            .HasOne(i => i.concealmen)
                            .WithMany(ic => ic.items)
                            .HasForeignKey(i => i.concealment_id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                            .HasOne(i => i.type)
                            .WithMany(it => it.items)
                            .HasForeignKey(i => i.type_id)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}