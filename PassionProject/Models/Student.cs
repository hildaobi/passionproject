using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace PassionProject.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set;}

       
        //student course taken
        public ICollection<Course> Courses { get; set; }
    }
   
     public class StudentDto
     {
        public int  StudentId { get; set;}

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Student> Courses { get;  set; }
     }
}

