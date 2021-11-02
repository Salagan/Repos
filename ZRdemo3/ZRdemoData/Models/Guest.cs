using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class Guest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<GuestTraining> GuestTrainings { get; set; }
    }
}
