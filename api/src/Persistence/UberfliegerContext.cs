using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence
{
    public class UberfliegerContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public UberfliegerContext(DbContextOptions<UberfliegerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.UseIdentityAlwaysColumns();

            modelBuilder.ConfigureProduct();
        }
    }
}
