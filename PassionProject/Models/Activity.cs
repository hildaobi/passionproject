using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace PassionProject.Models
{
    public class Activity
    {
        [Key]
        public string ActivityId { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

      


        //foreign key
        //activity have different student
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        
        //foreign key
        //activity have different student
        [ForeignKey("Course")]
        public int Coursecode { get; set; }
        public virtual Course Course { get; set;}





    }
    
}