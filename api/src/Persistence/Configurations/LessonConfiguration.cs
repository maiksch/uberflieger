using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public static class LessonConfiguration
    {
        public static void ConfigureLesson(this ModelBuilder modelBuilder)
        {
            // Setup
            modelBuilder.Entity<Lesson>()
                        .HasIndex(lesson => new { lesson.ModuleId, lesson.LessonNo })
                        .IsUnique();

            modelBuilder.Entity<Lesson>()
                        .Property(lesson => lesson.Title)
                        .IsRequired()
                        .HasMaxLength(255);

            // Seed
            modelBuilder.Entity<Lesson>().HasData(new
            {
                Id = 1,
                ModuleId = 1,
                VideoId = 1,
                LessonNo = 1,
                Title = "Herzlich willkommen",
            },
            new
            {
                Id = 2,
                ModuleId = 1,
                VideoId = 1,
                LessonNo = 2,
                Title = "Programmüberblick",
            });
        }
    }
}
