using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public static class ProductConfiguration
    {

        public static void ConfigureProduct(this ModelBuilder modelBuilder)
        {
            // Setup
            modelBuilder.Entity<Product>()
                        .HasIndex(product => product.Identifier)
                        .IsUnique();

            modelBuilder.Entity<Product>()
                        .Property(product => product.Identifier)
                        .IsRequired()
                        .HasMaxLength(255);

            modelBuilder.Entity<Product>()
                        .Property(product => product.Title)
                        .IsRequired()
                        .HasMaxLength(255);

            modelBuilder.Entity<Product>()
                        .Property(product => product.Description)
                        .HasColumnType("TEXT");

            // Seed
            modelBuilder.Entity<Product>().HasData(new
            {
                Id = 1,
                ThumbnailId = 1,
                Identifier = "uberflieger",
                Title = "Überflieger",
                Description = "Herzlich willkommen! Das Überflieger-Programm richtet sich an ehrgeizige, ambitionierte Ingenieure, die nach beruflichen Erfolgen streben. In diesem Programm erhältst du vielseitige Inspiration und Hilfsmittel für deine persönliche und berufliche Entwicklung."
            });
        }
    }
}
