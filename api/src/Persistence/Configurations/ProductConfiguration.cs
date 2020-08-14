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
                ProductId = 1,
                Identifier = "outcome-based-leadership",
                Title = "Outcome-based Leadership",
                Description = "Im Outcome-based Leadership Programm lernst du, wie du nachhaltig Führungskompetenzen aufbaust und dich Schritt-für-Schritt zu einer erfolgreichen Führungskraft entwickelst. Dies ist ein \"Umsetzungsprogramm\", das dir dabei hilft, erstklassige Ergebnisse zu erzielen."
            });
        }
    }
}
