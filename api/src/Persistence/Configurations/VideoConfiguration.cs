using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public static class VideoConfiguration
    {
        public static void ConfigureVideo(this ModelBuilder modelBuilder)
        {
            // Setup
            modelBuilder.Entity<Video>()
                        .HasIndex(video => video.StorageId)
                        .IsUnique();

            modelBuilder.Entity<Video>()
                        .Property(video => video.StorageId)
                        .IsRequired();

            modelBuilder.Entity<Video>()
                        .Property(video => video.FileType)
                        .IsRequired();

            // Seed
            modelBuilder.Entity<Video>().HasData(new
            {
                Id = 1,
                StorageId = "23d08787-9ce3-4fed-abd0-dcc0b259cbba",
                FileType = "webm",
            });
        }
    }
}
