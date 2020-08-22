using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public static class ImageConfiguration
    {
        public static void ConfigureImage(this ModelBuilder modelBuilder)
        {
            // Setup
            modelBuilder.Entity<Image>()
                        .HasIndex(image => image.StorageId)
                        .IsUnique();

            modelBuilder.Entity<Image>()
                        .Property(image => image.StorageId)
                        .IsRequired();

            modelBuilder.Entity<Image>()
                        .Property(image => image.FileType)
                        .IsRequired();

            // Seed
            modelBuilder.Entity<Image>().HasData(new
            {
                Id = 1,
                StorageId = "f58ebbbf-c09b-4802-ac75-af04571a591e",
                FileType = "jfif",
            });
        }
    }
}
