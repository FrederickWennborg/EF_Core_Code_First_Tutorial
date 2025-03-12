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

        public void UpdateStudent()
        {

            foreach (var student in _dbContext.Students)
            {
                if (student.Name == "Kalle")
                {
                    student.Name = "Karl";
                }
            }

            _dbContext.SaveChanges();
        }


    }
}
