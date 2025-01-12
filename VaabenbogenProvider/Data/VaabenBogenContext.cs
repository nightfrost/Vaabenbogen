using Microsoft.EntityFrameworkCore;
using VaabenbogenProvider.Models;

namespace VaabenbogenProvider.Data
{
    public class VaabenBogenContext : DbContext
    {
        public VaabenBogenContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Jaeger> Jaegere { get; set; }
        public DbSet<Vaaben> Vaaben { get; set; }
        public DbSet<Virksomhed> Virksomheder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Ejer>(); // Exclude Ejer from the database

            modelBuilder.Entity<Jaeger>()
                .ToTable("Jaegere"); // Map Jaeger to the Jaegere table

            modelBuilder.Entity<Virksomhed>()
                .ToTable("Virksomheder"); // Map Virksomhed to the Virksomheder table

            modelBuilder.Entity<Vaaben>()
                .ToTable("Vaaben");
        }
    }
}
