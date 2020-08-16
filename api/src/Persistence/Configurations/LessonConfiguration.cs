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
                        .HasIndex(module => new { module.ModuleId, module.LessonNo })
                        .IsUnique();

            modelBuilder.Entity<Lesson>()
                        .Property(module => module.Title)
                        .IsRequired()
                        .HasMaxLength(255);

            // Seed
            modelBuilder.Entity<Lesson>().HasData(new
            {
                Id = 1,
                ModuleId = 1,
                LessonNo = 1,
                Title = "Lesson Nummer 1",
            });
        }
    }
}
