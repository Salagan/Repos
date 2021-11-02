using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class CoachTrainingDay
    {
        public int CoachId { get; set; }

        public virtual Coach Coach { get; set; }

        public int TrainingDayId { get; set; }

        public virtual TrainingDay TrainingDay { get; set; }
    }
}
