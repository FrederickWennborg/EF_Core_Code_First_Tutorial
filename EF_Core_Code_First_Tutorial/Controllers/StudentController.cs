using EF_Core_Code_First_Tutorial.Contexts;
using EF_Core_Code_First_Tutorial.Entities;
using EF_Core_Code_First_Tutorial.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Code_First_Tutorial.Controllers
{
    public class StudentController
    {
        private StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        public void RegisterNewStudent()
        {
            Console.WriteLine("Skriv in studentens uppgifter: ");

            Console.WriteLine($"{Environment.NewLine}Namn:");
            Console.Write(">");
            var name = Console.ReadLine();
            Console.Write(">");
            Console.WriteLine($"{Environment.NewLine}Email:");
            var email = Console.ReadLine();
            Console.WriteLine($"{Environment.NewLine}Telefon:");
            Console.Write(">");
            var phone = Console.ReadLine();

            var availableCourses = _studentService.GetCourses();


            Console.WriteLine($"{Environment.NewLine}Välj kurs:");

            var counter = 1;
            foreach (var course in availableCourses)
            {
                Console.WriteLine($"{counter}. {course.CourseName}");
                counter++;
            }

            var selection = ValidateSelection(availableCourses.Count);

            var selectedCourse = availableCourses[selection - 1];

            var newStudent = new Student
            {
                Name = name,
                Email = email,
                PhoneNumber = phone,
                Course = selectedCourse
            };

            _studentService.CreateStudent(newStudent);

            Console.WriteLine("Studenten har registrerats!");

        }

        public static int ValidateSelection(int selectionMenuLimit)
        {
            int intSelection;
            Console.WriteLine($"{Environment.NewLine}Välj i menyn:");
            while (true)
            {
                Console.Write("> ");
                if (int.TryParse(Console.ReadLine(), out intSelection) && intSelection >= 0 && intSelection <= selectionMenuLimit)
                    return intSelection;



                Console.WriteLine("Fel val");
            }

        }

        public void EditStudentInformation()
        {
            throw new NotImplementedException();
        }

        public void RemoveStudent()
        {
            throw new NotImplementedException();
        }

        public void ListStudents()
        {
            throw new NotImplementedException();
        }
    }
}
