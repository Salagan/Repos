using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoContracts.Enum;

namespace ZRdemoContracts.ModelsDTO
{
    public class GroupOfStudentsDTO
    {
        public int Id { get; set; }

        public GroupType GroupType { get; set; }

        public string GroupAge { get; set; }

        public List<StudentDTO> Students { get; set; }

        public List<TrainingDTO> Trainings { get; set; }
    }
}
