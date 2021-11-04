using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class Gym
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public bool IsAvailable { get; set; }

        public string WorkingHours { get; set; }
    }
}
