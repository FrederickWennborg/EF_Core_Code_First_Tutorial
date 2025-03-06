using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Code_First_Tutorial.Entities
{
    public class Course
    {
        public int CourseId { get; set; } 
        public string CourseName { get; set; } = null!;
        public List<Student> Students { get; set; } = null!;
        public List<Lesson> Lessons { get; set; } = null!;

    }

}
