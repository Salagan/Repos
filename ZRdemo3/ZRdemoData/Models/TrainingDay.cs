using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class TrainingDay
    {
        public TrainingDay()
        {
            this.GroupOfStudents = new HashSet<GroupOfStudents>();
            this.Coaches = new HashSet<Coach>();
            this.Gyms = new HashSet<Gym>();
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public bool IsHolliday { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }

        public virtual ICollection<Gym> Gyms { get; set; }

        public virtual ICollection<Coach> Coaches { get; set; }

        public virtual ICollection<GroupOfStudents> GroupOfStudents { get; set; }
    }
}
