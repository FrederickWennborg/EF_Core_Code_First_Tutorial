using EF_Core_Code_First_Tutorial.Contexts;
using EF_Core_Code_First_Tutorial.Controllers;
using EF_Core_Code_First_Tutorial.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Code_First_Tutorial.Menus
{
    public class Menu
    {
        private ApplicationDbContext _dbContext;
        public Menu(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public void Start()
        {

            Console.WriteLine("1. Create student");
            Console.WriteLine("2. Update student");
            Console.WriteLine("3. Delete student");
            Console.WriteLine("4. List students");
            Console.WriteLine("5. Exit");
            var choice = Console.ReadLine();

            var studentController = new StudentController(new StudentService(_dbContext));


            switch (choice)
            {
                case "1":
                    Console.Clear();
                    studentController.RegisterNewStudent();
                    break;
                case "2":
                    Console.Clear();
                    studentController.EditStudentInformation();
                    break;
                case "3":
                    Console.Clear();
                    studentController.RemoveStudent();
                    break;
                case "4":
                    Console.Clear();
                    studentController.ListStudents();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }


    }
}
