using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PassionProject.Models
{
    public class Course
    {

        [Key]
        public int CourseCode { get; set; }
        //describing course
        public string CourseName { get; set; }

        public ICollection<Course> Courses { get; set;}

    public ICollection<Activity> Activities { get; set; }
    }
<<<<<<< HEAD

    public class CourseDto
    {
        public int CourseCode{ get; set; }

        public string CourseName { get; set; }

       
    }
=======
>>>>>>> d8c5891b2468e175134fdc206cfae6f8b3e0b55d
}