using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class GroupOfStudentsTrainingDay
    {
        public int GroupOfStudentsId { get; set; }

        public virtual GroupOfStudents GroupOfStudents { get; set; }

        public int TrainingDayId { get; set; }

        public virtual TrainingDay TrainingDay { get; set; }
    }
}
