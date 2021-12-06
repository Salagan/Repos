using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoData.Enums;

namespace ZRdemoData.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public int? GroupOfStudentsId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }

        public bool Injury { get; set; }

        public Belts Belt { get; set; }

        public virtual GroupOfStudents GroupOfStudents { get; set; }
    }
}
