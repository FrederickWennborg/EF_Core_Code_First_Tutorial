using EF_Core_Code_First_Tutorial.Contexts;
using EF_Core_Code_First_Tutorial.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Code_First_Tutorial.Services
{
   public class StudentService
    {
        ApplicationDbContext _dbContext;
       
        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateStudent(Student student)
        {

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }


        public Student GetStudent(int studentId)
        {
            return null;
        }


        public List<Student> GetAllStudents()
        {
            return null;
        }


        public string UpdateStudent(int studentId)
        {

            return "Return status message (success or failure)";
        }

        public string DeleteStudent()
        {
            return "Return status message (success or failure)";
        }


        public List<Course> GetCourses()
        {
          return _dbContext.Courses.ToList();
        }

    }
}
