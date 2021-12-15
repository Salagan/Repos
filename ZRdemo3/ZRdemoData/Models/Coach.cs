using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoData.Enums;

namespace ZRdemoData.Models
{
    public class Coach
    {
        public Coach()
        {
            this.Trainings = new HashSet<Training>();
        }

        public int CoachId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }

        public bool IsWorking { get; set; }

        public Belts Belt { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public ICollection<Training> Trainings { get; set; }

        public ICollection<Announcement> Announcements { get; set; }
    }
}
