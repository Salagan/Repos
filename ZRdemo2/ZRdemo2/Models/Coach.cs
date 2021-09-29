using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZRdemo2.Models
{
    public class Coach : Member
    {
        public int Id { get; set; }
        public Gender Gender { get; set; }
        public TrainingDays Days { get; set; }
        public DateTime BirthDate { get; set; }

    }
}