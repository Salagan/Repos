using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class GuestCoach
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public Belts Belt { get; set; }

        public string SchoolName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }
    }
}
