using Domain;
using Microsoft.EntityFrameworkCore;
using System;

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
                StorageId = new Guid("f58ebbbf-c09b-4802-ac75-af04571a591e"),
                Uri = "http://127.0.0.1:10000/devstoreaccount1/thumbnails/f58ebbbf-c09b-4802-ac75-af04571a591e.jfif",
                FileType = "jfif",
            });
        }
    }
}