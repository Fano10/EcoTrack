using EcoTrack.SuiviEmpreinteCarbone.API.Model;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.SuiviEmpreinteCarbone.API.Data
{
    public class UserContext: DbContext
    {
        
            public UserContext() : base() { }
            public UserContext(DbContextOptions<UserContext> options) : base(options) { }
            public virtual DbSet<User> Users { get; set; }
            public virtual DbSet<Carbone> Carbones { get; set; }    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<User>()
                    .HasKey(u => u.Id);
                modelBuilder.Entity<User>()
                    .HasIndex(u => u.Sub)
                    .IsUnique();
                modelBuilder.Entity<User>()
                    .Property(u => u.Sub)
                    .IsRequired();
                modelBuilder.Entity<User>()
                    .Property(u => u.Name)
                    .IsRequired();
                modelBuilder.Entity<Carbone>()
                    .HasKey(c => c.Id);
                modelBuilder.Entity<Carbone>()
                    .Property(c => c.Quantity)
                    .IsRequired();
            }
        }
}
