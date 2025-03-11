using EF_Core_Code_First_Tutorial.Contexts;
using EF_Core_Code_First_Tutorial.Data;
using EF_Core_Code_First_Tutorial.Entities;
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
         
           var dbContext = DataInitializer.Build();
           dbContext = DataInitializer.InitializeData(dbContext);



            var studentService = new StudentService(dbContext);



            
            //if (dbContext.Students.IsNullOrEmpty())
            //{

            //    studentService.CreateStudent(new Student
            //    {
            //        Name = "Kalle",
            //        Email = "kalle@hotmail.se",
            //        PhoneNumber = "07o01234567",
            //        Course = new Course
            //        {
            //            CourseName = "Databashantering",
            //            Lessons = new List<Lesson>
            //        {
            //            new Lesson { ClassRoom = "Södermalm", LessonDate = DateTime.Now },
            //        }
            //        }

            //    });


            //    studentService.CreateStudent(new Student
            //    {
            //        Name = "Anna",
            //        Email = "anna@hotmail.com",
            //        PhoneNumber = "07o01234567",
            //        Course = dbContext.Courses.FirstOrDefault(c => c.CourseName == "Databashantering")!
            //    });


            //    Console.WriteLine("Två studenter, en kurs och en lektion skapad och genererad till databasen!");

            //}

        }


    }

}
