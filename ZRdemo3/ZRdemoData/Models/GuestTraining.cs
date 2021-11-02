using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class GuestTraining
    {
        public int GuestId { get; set; }

        public virtual Guest Guest { get; set; }

        public int TrainingId { get; set; }

        public virtual Training Training { get; set; }
    }
}
