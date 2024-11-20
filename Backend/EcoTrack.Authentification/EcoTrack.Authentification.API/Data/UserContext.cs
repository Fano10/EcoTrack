using EcoTrack.Authentification.API.Model;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.Authentification.API.Data
{
    public class UserContext: DbContext
    {
        public UserContext() : base() { }
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired();
        }
    }
}
