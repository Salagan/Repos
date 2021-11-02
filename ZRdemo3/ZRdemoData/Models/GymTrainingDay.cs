using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class GymTrainingDay
    {
        public int GymId { get; set; }

        public Gym Gym { get; set; }

        public int TrainingDayID { get; set; }

        public virtual TrainingDay TrainingDay { get; set; }
    }
}
