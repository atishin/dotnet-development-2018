using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFStudents.Models.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Document> Documents { get; set; }
    }

    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.People.Any())
            {
                return;
            }

            context.People.Add(new Person()
            {
                Name = "Vasya",
                Age = 25
            });

            context.SaveChanges();

        }
    }
}