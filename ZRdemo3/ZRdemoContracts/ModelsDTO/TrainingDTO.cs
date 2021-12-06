using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoContracts.Enum;

namespace ZRdemoContracts.ModelsDTO
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

        public GymDTO Gym { get; set; }

        public CoachDTO Coach { get; set; }

        public GroupOfStudentsDTO GroupOfStudents { get; set; }
    }
}
