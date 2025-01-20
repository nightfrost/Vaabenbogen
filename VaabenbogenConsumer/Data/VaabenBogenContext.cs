using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VaabenbogenConsumer.Models;

namespace VaabenbogenConsumer.Data
{
    public class VaabenBogenContext : IdentityDbContext
    {
        public VaabenBogenContext(DbContextOptions<VaabenBogenContext> options)
            : base(options)
        {
        }

        public DbSet<Jaeger> Jaegere { get; set; }
        public DbSet<Vaaben> Vaaben { get; set; }
        public DbSet<Virksomhed> Virksomheder { get; set; }
        public DbSet<Udskrivelser> Udskrivelser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure Identity configuration is applied
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Ejer>(); // Exclude Ejer from the database

            modelBuilder.Entity<Jaeger>()
                .ToTable("Jaegere"); // Map Jaeger to the Jaegere table

            modelBuilder.Entity<Virksomhed>()
                .ToTable("Virksomheder"); // Map Virksomhed to the Virksomheder table

            modelBuilder.Entity<Vaaben>()
                .ToTable("Vaaben");

            modelBuilder.Entity<Udskrivelser>()
                .ToTable("Udskrivelser");
        }
    }
}
