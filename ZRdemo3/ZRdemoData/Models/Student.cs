using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public enum Belts
    {
        White,
        Grey,
        Yellow,
        Orange,
        Green,
        Blue,
        Purple,
        Brown,
        Black,
    }

    public class Student
    {
        public int Id { get; set; }

        public int CoachId { get; set; }

        public int GroupOfStudentsId { get; set; }

        public MemberOfTheTeam MemberData { get; set; }

        public bool Injury { get; set; }

        public Belts Belt { get; set; }

        public virtual Coach Coach { get; set; }

        public virtual GroupOfStudents Group { get; set; }
    }
}
