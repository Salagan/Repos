using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZRdemo2.Models
{
    public class Student : Member
    {
        public int Id { get; set; }
                
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Injury { get; set; }

    }
}