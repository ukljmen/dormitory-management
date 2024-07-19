using DormAPI.Models.Entities;
using DormAPI.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DormAPI.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Conservator> Conservators { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<DirectMessage> DirectMessages { get; set; }
        public DbSet<DirectMessageStudent> DirectMessageStudents { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            InitializeDatabase(builder);

            builder.Entity<DirectMessageStudent>(e =>
            {
                e.HasKey(e => new { e.StudentId, e.DirectMessageId });

                e.HasOne(dms => dms.DirectMessage)
                    .WithMany(dm => dm.DirectMessageStudents)
                    .HasForeignKey(dms => dms.DirectMessageId);
            });

            builder.Entity<Manager>(e =>
            {
                e.HasOne(m => m.User)
                    .WithOne()
                    .HasForeignKey<Manager>(x => x.UserId);

                e.HasMany(m => m.DirectMessagesSent)
                    .WithOne(dms => dms.Manager)
                    .HasForeignKey(x => x.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            builder.Entity<Conservator>(e =>
            {
                e.HasOne(c => c.User)
                    .WithOne()
                    .HasForeignKey<Conservator>(x => x.UserId);

                e.HasMany(c => c.Problems)
                    .WithOne(p => p.Conservator)
                    .HasForeignKey(p => p.ConservatorId);
            });

            builder.Entity<Student>(e =>
            {
                e.HasOne(s => s.User)
                    .WithOne()
                    .HasForeignKey<Student>(x => x.UserId);

                e.HasMany(s => s.Problems)
                    .WithOne()
                    .HasForeignKey(p => p.StudentId);

                e.HasMany(s => s.DirectMessageStudents)
                    .WithOne(dms => dms.Student)
                    .HasForeignKey(msg => msg.StudentId);
            });

            builder.Entity<Item>(e =>
            {
                e.HasMany(e => e.Problems)
                    .WithOne(p => p.Item)
                    .HasForeignKey(i => i.ItemId);
            });

            builder.Entity<Room>(e =>
            {
                e.HasMany(e => e.Items)
                    .WithOne()
                    .HasForeignKey(i => i.RoomId);

                e.HasMany(e => e.Students)
                    .WithOne()
                    .HasForeignKey(s => s.RoomId);
            });

            builder.Entity<Floor>(e =>
            {
                e.HasMany(f => f.Rooms)
                    .WithOne()
                    .HasForeignKey(r => r.FloorId);

                e.HasIndex(f => f.FloorNumber)
                    .IsUnique();
            });

            builder.Entity<Announcement>(e =>
            {
                e.HasOne(e => e.Manager)
                    .WithMany(m => m.AnnouncementsSent)
                    .HasForeignKey(x => x.ManagerId);
            });
        }

        private void InitializeDatabase(ModelBuilder builder)
        {
            InitializeRoles(builder);
            InitializeAdmin(builder);
        }

        private void InitializeRoles(ModelBuilder builder)
        {
            var roles = Enum.GetValues<UserRole>()
                .Select(
                    role => new Role(Enum.GetName(role)!)
                    {
                        Id = (int)role,
                        NormalizedName = Enum.GetName(role)!.ToUpper(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    }
                ).ToList();

            builder.Entity<Role>()
                .HasData(roles);
        }

        private void InitializeAdmin(ModelBuilder builder)
        {
            var admin = new User()
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.pl",
                NormalizedEmail = "ADMIN@ADMIN.PL",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEOh5Z7hox3MAByrWwXaH29QZy6spjBNOf3x0sWnZCaXtcaNezWGwd/hjC+eDV9EDIg==",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            var adminManager = new Manager()
            {
                Id = 1,
                FirstName = "manager",
                LastName = "admin",
                UserId = 1
            };

            builder.Entity<User>()
                .HasData(admin);

            builder.Entity<Manager>()
                .HasData(adminManager);
        }
    }
}
