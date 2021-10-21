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

    public enum Gender
    {
        Male,
        Female,
        Other,
    }

    public class Student
    {
        public int StudentId { get; set; }

        public int CoachId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }

        public bool Injury { get; set; }

        public Belts Belt { get; set; }

        public virtual Coach Coach { get; set; }

        public virtual GroupOfStudents Group { get; set; }
    }
}
