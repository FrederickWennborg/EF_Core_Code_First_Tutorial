using EF_Core_Code_First_Tutorial.Contexts;
using EF_Core_Code_First_Tutorial.Entities;
using EF_Core_Code_First_Tutorial.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Code_First_Tutorial.Data
{
    public class DataInitializer
    {

        public static ApplicationDbContext Build()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseSqlServer(connectionString)
             .Options;

            using var dbContext = new ApplicationDbContext(contextOptions!);
            dbContext.Database.Migrate();

            return dbContext;
        }

        public static ApplicationDbContext InitializeData(ApplicationDbContext dbContext)
        {
            if (!IfAnyDataExists(dbContext))
            {
                GenerateCourses(dbContext);
                GenerateStudents(dbContext);
                GenerateLessons(dbContext);
            }

            return dbContext;
        }


        public static bool IfAnyDataExists(ApplicationDbContext dbContext)
        {
            return dbContext.Courses.Any() || dbContext.Students.Any() || dbContext.Lessons.Any();
        }

        public static void GenerateCourses(ApplicationDbContext dbContext)
        {
          
                dbContext.Courses.Add(new Course
                {
                    CourseName = "Databashantering"
                });

            dbContext.SaveChanges();
        }

        public static void GenerateStudents(ApplicationDbContext dbContext)
        {

            dbContext.Students.Add(new Student
            {
                Name = "Kalle",
                Email = "kalle@hotmail.se",
                PhoneNumber = "07o01234567",
                Course = dbContext.Courses.FirstOrDefault(c => c.CourseName == "Databashantering")!
            });

            dbContext.Students.Add(new Student
            {
                Name = "Anna",
                Email = "anna@hotmail.com",
                PhoneNumber = "07o01234567",
                Course = dbContext.Courses.FirstOrDefault(c => c.CourseName == "Databashantering")!
            });

            dbContext.Students.Add(new Student
            {
                Name = "Erik",
                Email = "Erik@hotmail.com",
                PhoneNumber = "07o01234567",
                Course = dbContext.Courses.FirstOrDefault(c => c.CourseName == "Databashantering")!
            });

            dbContext.Students.Add(new Student
            {
                Name = "My",
                Email = "My@hotmail.com",
                PhoneNumber = "07o01234567",
                Course = dbContext.Courses.FirstOrDefault(c => c.CourseName == "Databashantering")!
            });

            dbContext.SaveChanges();
        }
        public static void GenerateLessons(ApplicationDbContext dbContext)
        {

            dbContext.Lessons.Add(new Lesson
            {
                ClassRoom = "Södermalm",
                LessonDate = new DateTime(2025, 2, 22),
                Course = dbContext.Courses.FirstOrDefault(c => c.CourseName == "Databashantering")!
            });

            dbContext.Lessons.Add(new Lesson
            {
                ClassRoom = "Södermalm",
                LessonDate = new DateTime(2025, 3, 1),
                Course = dbContext.Courses.FirstOrDefault(c => c.CourseName == "Databashantering")!
            });

            dbContext.Lessons.Add(new Lesson
            {
                ClassRoom = "Södermalm",
                LessonDate = new DateTime(2025, 3, 8),
                Course = dbContext.Courses.FirstOrDefault(c => c.CourseName == "Databashantering")!
            });

            dbContext.Lessons.Add(new Lesson
            {
                ClassRoom = "Södermalm",
                LessonDate = new DateTime(2025, 3, 15),
                Course = dbContext.Courses.FirstOrDefault(c => c.CourseName == "Databashantering")!
            });

            dbContext.SaveChanges();
        }
    }
}
