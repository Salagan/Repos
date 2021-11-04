using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    // instructors from other school or club
    public class Guest
    {
        public Guest()
        {
            this.GuestTrainings = new HashSet<GuestTraining>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public Belts Belt { get; set; }

        public string SchoolName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<GuestTraining> GuestTrainings { get; set; }
    }
}
