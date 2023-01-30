using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using VTT.Models.Entities;


namespace VTT.Data
{
    // Context - klasa konfiguracyjna EF Core
    public class AppDbContext : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<World> World { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<User_World> User_World { get; set; }
        public DbSet<Character_Item> Character_Item { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Item_Availability> Item_Availabilitie { get; set; }
        public DbSet<Item_Concealment> Item_Concealment { get; set; }
        public DbSet<Item_Type> Item_Type { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.id);
                entity.Property(u => u.login);
                entity.Property(u => u.password);
                entity.Property(u => u.isAdmin);
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
                entity.Property(c => c.reflex);
                entity.Property(c => c.dexterity);
                entity.Property(c => c.body);
                entity.Property(c => c.speed);
                entity.Property(c => c.empathy);
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

            modelBuilder.Entity<User_World>(entity =>
            {
            entity.ToTable("Users_Worlds");
            entity.HasKey(uw => uw.id);
            entity.Property(uw => uw.user_id);
            entity.Property(uw => uw.world_id);
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
                entity.Property(i => i.name);
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

            modelBuilder.Entity<Item_Concealment>(entity =>
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


            modelBuilder.Entity<User_World>()
                            .HasOne(u => u.User)
                            .WithMany(uw => uw.Users_Worlds_Characters)
                            .HasForeignKey(u => u.user_id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User_World>()
                            .HasOne(w => w.World)
                            .WithMany(uw => uw.Users_Worlds)
                            .HasForeignKey(w => w.world_id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character>()
                            .HasOne(c => c.Users_Worlds)
                            .WithMany(uw => uw.Characters)
                            .HasForeignKey(uw => uw.id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character_Item>()
                            .HasOne(c => c.Character)
                            .WithMany(c => c.Items)
                            .HasForeignKey(c => c.character_id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character_Item>()
                            .HasOne(ci => ci.Item)
                            .WithOne(i => i.Character_Item)
                            .HasForeignKey<Character_Item>(ci => ci.item_id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                            .HasOne(i => i.availability)
                            .WithMany(ia => ia.items)
                            .HasForeignKey(i => i.availability_id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                            .HasOne(i => i.concealment)
                            .WithMany(ic => ic.items)
                            .HasForeignKey(i => i.concealment_id)
                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                            .HasOne(i => i.type)
                            .WithMany(it => it.items)
                            .HasForeignKey(i => i.type_id)
                            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Item_Availability>().HasData(

                new Item_Availability() { id = 1, name = "Everywhere" },
                new Item_Availability() { id = 2, name = "Common" },
                new Item_Availability() { id = 3, name = "Poor" },
                new Item_Availability() { id = 4, name = "Rare" }
            );

            modelBuilder.Entity<Item_Concealment>().HasData(

                new Item_Concealment() { id = 1, name = "Tiny" },
                new Item_Concealment() { id = 2, name = "Small" },
                new Item_Concealment() { id = 3, name = "Large" },
                new Item_Concealment() { id = 4, name = "Can't Hide" }
            );

            modelBuilder.Entity<Item_Type>().HasData(

                new Item_Type() { id = 1, name = "Weapon" },
                new Item_Type() { id = 2, name = "Armour" },
                new Item_Type() { id = 3, name = "Potion" },
                new Item_Type() { id = 4, name = "Tool" }
            );

            modelBuilder.Entity<User>().HasData(

                 new User() { id = 1, login = "admin", password = "admin", isAdmin = true }
            );
        }
    }
}