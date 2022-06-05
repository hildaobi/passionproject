using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PassionProject.Models
{
    public class Person
    {
        //primary key
        [Key]
        public int PersonId { get; set; }
        //describing person
        public string PersonName { get; set; }

        public string PersonLastName { get; set; }
    }
}