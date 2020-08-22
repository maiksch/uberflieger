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
                Identifier = "einstieg",
                Title = "Einstieg",
            },
            new
            {
                Id = 2,
                ProductId = 1,
                Identifier = "modul-1-personlichkeit-ergrunden",
                Title = "Modul 1 - Persönlichkeit ergründen",
            },
            new
            {
                Id = 3,
                ProductId = 1,
                Identifier = "modul-2-ziele-und-roadmap-erarbeiten",
                Title = "Modul 2 - Ziele & Roadmap erarbeiten",
            });
        }
    }
}
