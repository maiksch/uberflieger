using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public static class ModuleConfiguration
    {
        public static void ConfigureModule(this ModelBuilder modelBuilder)
        {
            // Setup
            modelBuilder.Entity<Module>()
                        .HasIndex(module => module.Identifier)
                        .IsUnique();

            modelBuilder.Entity<Module>()
                        .Property(module => module.Identifier)
                        .IsRequired()
                        .HasMaxLength(255);

            modelBuilder.Entity<Module>()
                        .Property(module => module.Title)
                        .IsRequired()
                        .HasMaxLength(255);

            // Seed
            modelBuilder.Entity<Module>().HasData(new
            {
                Id = 1,
                ProductId = 1,
                Identifier = "module-1-persoenliches-wachstum",
                Title = "Modul 1 - Persönliches Wachstum",
            });
        }
    }
}
