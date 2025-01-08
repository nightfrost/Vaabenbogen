using Microsoft.EntityFrameworkCore;
using VaabenbogenProvider.Models;

namespace VaabenbogenProvider.Data
{
    public class VaabenBogenContext : DbContext
    {
        public VaabenBogenContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Jaeger> Jaegere {  get; set; }
        public DbSet<Vaaben> Vaaben { get; set; }
    }
}
