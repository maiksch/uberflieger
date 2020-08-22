using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence
{
    public class UberfliegerContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Video> Videos { get; set; }

        public UberfliegerContext(DbContextOptions<UberfliegerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityAlwaysColumns();

            modelBuilder.ConfigureProduct();

            modelBuilder.ConfigureModule();

            modelBuilder.ConfigureLesson();

            modelBuilder.ConfigureVideo();
        }
    }
}
