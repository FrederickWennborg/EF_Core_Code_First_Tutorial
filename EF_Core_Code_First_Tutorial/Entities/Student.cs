
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Code_First_Tutorial.Entities
{
    public class Student
    {
        public int StudentId { get; set; }

        public Course Course { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;


    }
}
