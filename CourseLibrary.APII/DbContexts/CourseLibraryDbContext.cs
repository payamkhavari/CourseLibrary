using CourseLibrary.APII.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseLibrary.APII.DbContexts
{
    public class CourseLibraryDbContext : DbContext
    {
        public CourseLibraryDbContext(DbContextOptions<CourseLibraryDbContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed data into the database

            modelBuilder.Entity<Author>().HasData(new Author()
            {
                Id = Guid.Parse("449E14D5-B4DC-41B8-B563-1F229641C6B4"),
                FirstName = "Berry",
                LastName = "Griffin Beak Eldritch",
                DateofBirth = new DateTime(1650, 7, 23),
                MainCategory = "Ships"
            },
            new Author()
            {
                Id = Guid.Parse("E5EB6801-EFFB-474F-AADA-96D43E2A7994"),
                FirstName = "Nancy",
                LastName = "Swashbuckler Rye",
                DateofBirth = new DateTime(1668, 5, 21),
                MainCategory = "Rum"
            },
              new Author()
              {
                  Id = Guid.Parse("1C3C1278-F976-4FDA-82E1-D90E8EF03E77"),
                  FirstName = "Eli",
                  LastName = "Ivory Bones Sweet",
                  DateofBirth = new DateTime(1701, 12, 16),
                  MainCategory = "Singing"
              }

            );

            modelBuilder.Entity<Course>().HasData(new Course()
            {
                Id = Guid.Parse("9A494FF2-697F-4496-99CE-BC6B997548E8"),
                Title = "Romance of Arabica",
                Description = "Griffin Beak Eldritch",
                AuthorId = Guid.Parse("1C3C1278-F976-4FDA-82E1-D90E8EF03E77")

            },
            new Course()
            {
                Id = Guid.Parse("DD569C04-6B46-4326-BE09-C9CF9014A1C1"),
                Title = "Romance of Arabica",
                Description = "Griffin Beak Eldritch",
                AuthorId = Guid.Parse("E5EB6801-EFFB-474F-AADA-96D43E2A7994")
            },
            new Course()
            {
                Id = Guid.Parse("292765B0-2627-433A-AAE1-F58767BDA127"),
                Title = "Romance of Arabica",
                Description = "Griffin Beak Eldritch",
                AuthorId = Guid.Parse("1C3C1278-F976-4FDA-82E1-D90E8EF03E77")
            }
            );
        }
    }
}
