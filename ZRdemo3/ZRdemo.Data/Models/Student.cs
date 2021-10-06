using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemo.Data.Models
{
    class Student
    {
        public int Id { get; set; }
        public MemberOfTheTeam MemberData { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Injury { get; set; }
    }
}
