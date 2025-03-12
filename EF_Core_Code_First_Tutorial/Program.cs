using EF_Core_Code_First_Tutorial.Contexts;
using EF_Core_Code_First_Tutorial.Data;
using EF_Core_Code_First_Tutorial.Entities;
using EF_Core_Code_First_Tutorial.Menus;
using EF_Core_Code_First_Tutorial.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Channels;

namespace EF_Core_Code_First_Tutorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = DataInitializer.Build())
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //Hämtar vår connection string inuti appsettings.json med ConfigurationBuilder
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //Med vår connection string skapar vi en DbContextOption, alltså en inställning för vår databas.
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseSqlServer(connectionString)
             .Options;

            // Skapar ett objekt av ApplicationDbContext genom att skicka in våra inställningar som innehåller connection stringen.
            using var dbContext = new ApplicationDbContext(contextOptions!);

            dbContext.Database.Migrate();



            //Vi skapar en service! Vi skickar in vår DbContext som vi skapade ovan. Vi gör inget med servicen ännu, den finns bara där.

            var studentService = new StudentService(dbContext);



            //Eftersom vi genererar data sätter vi en validering. Annars kommer vi duplicera data varje gång vi kör programmet.
            if (dbContext.Students.IsNullOrEmpty())
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //Hämtar vår connection string inuti appsettings.json med ConfigurationBuilder
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //Med vår connection string skapar vi en DbContextOption, alltså en inställning för vår databas.
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseSqlServer(connectionString)
             .Options;

            // Skapar ett objekt av ApplicationDbContext genom att skicka in våra inställningar som innehåller connection stringen.
            using var dbContext = new ApplicationDbContext(contextOptions!);

            dbContext.Database.Migrate();



            //Vi skapar en service! Vi skickar in vår DbContext som vi skapade ovan. Vi gör inget med servicen ännu, den finns bara där.

            var studentService = new StudentService(dbContext);



            //Eftersom vi genererar data sätter vi en validering. Annars kommer vi duplicera data varje gång vi kör programmet.
            if (dbContext.Students.IsNullOrEmpty())
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //Hämtar vår connection string inuti appsettings.json med ConfigurationBuilder
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //Med vår connection string skapar vi en DbContextOption, alltså en inställning för vår databas.
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseSqlServer(connectionString)
             .Options;

            // Skapar ett objekt av ApplicationDbContext genom att skicka in våra inställningar som innehåller connection stringen.
            using var dbContext = new ApplicationDbContext(contextOptions!);

            dbContext.Database.Migrate();



            //Vi skapar en service! Vi skickar in vår DbContext som vi skapade ovan. Vi gör inget med servicen ännu, den finns bara där.

            var studentService = new StudentService(dbContext);



            //Eftersom vi genererar data sätter vi en validering. Annars kommer vi duplicera data varje gång vi kör programmet.
            if (dbContext.Students.IsNullOrEmpty())
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //Hämtar vår connection string inuti appsettings.json med ConfigurationBuilder
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //Med vår connection string skapar vi en DbContextOption, alltså en inställning för vår databas.
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseSqlServer(connectionString)
             .Options;

            // Skapar ett objekt av ApplicationDbContext genom att skicka in våra inställningar som innehåller connection stringen.
            using var dbContext = new ApplicationDbContext(contextOptions!);

            dbContext.Database.Migrate();



            //Vi skapar en service! Vi skickar in vår DbContext som vi skapade ovan. Vi gör inget med servicen ännu, den finns bara där.

            var studentService = new StudentService(dbContext);



            //Eftersom vi genererar data sätter vi en validering. Annars kommer vi duplicera data varje gång vi kör programmet.
            if (dbContext.Students.IsNullOrEmpty())
            {

                //Vi skapar en student via studentservice. Eftersom vi inte har några kurser eller lektioner ännu, måste vi skapa dessa också.
                studentService.CreateStudent(new Student
                {
                    Name = "Kalle",
                    Email = "kalle@hotmail.se",
                    PhoneNumber = "07o01234567",
                    Course = new Course
                    {
                        CourseName = "Databashantering",
                        Lessons = new List<Lesson>
                    {
                        new Lesson { ClassRoom = "Södermalm", LessonDate = DateTime.Now },
                    }
                    }

                });

                /* Vi skapar en student till. Men titta! Vi har redan skapat en kurs ovan. 
                 * Om vi vill att Anna också ska kopplas till databashantering,
                 * så kan vi "hämta" kursen från databasen istället med hjälp av LINQ. 
                 * Anna kommer nu också att vara kopplade till databashantering och även alla lektioner
                 * som finns tillgängliga för den kursen. */

                studentService.CreateStudent(new Student
                {
                    Name = "Anna",
                    Email = "anna@hotmail.com",
                    PhoneNumber = "07o01234567",
                    Course = dbContext.Courses.FirstOrDefault(c => c.CourseName == "Databashantering")!
                });


                Console.WriteLine("Två studenter, en kurs och en lektion skapad och genererad till databasen!");

            }

        }
    }

}
