using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Code_First_Tutorial.Entities
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        public Course Course { get; set; } = null!;

        [StringLength(100)]
        public string ClassRoom { get; set; } = null!;
        public DateTime LessonDate { get; set; } 
    }

}
