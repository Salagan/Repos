using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class GroupOfStudents
    {
        public int Id { get; set; }
        public int CoachId { get; set; }
        public int GymID { get; set; }
        public GroupType GroupType { get; set; }
        public string GroupAge { get; set; }
        
        

        public virtual Coach Coach { get; set; }
        public virtual Gym Gym { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<TrainingDay> TrainingDays { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
    }
    public enum GroupType
    {
        AdultBeginers,
        AdultAdvance,
        Kids,
        Junior,
        Juvenile
    }

}
