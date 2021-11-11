using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoBll.Enums;

namespace ZRdemoBll.ModelsDTO
{
    public class TrainingDTO
    {
        public int Id { get; set; }

        // keys
        public int GymId { get; set; }

        public int CoachId { get; set; }

        public int GroupOfStudentsId { get; set; }

        // entity properties
        public DateTime TimeStart { get; set; }

        public Uniform Uniform { get; set; }

        public TypeOfTraining TypeOfTraining { get; set; }
    }
}
