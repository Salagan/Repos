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
            this.Gyms = new HashSet<Gym>();
        }

        public int Id { get; set; }

        public int GymId { get; set; }

        public DateTime Date { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public bool IsHolliday { get; set; }

        public virtual Gym Gym { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }

        public virtual ICollection<Gym> Gyms { get; set; }

        public virtual ICollection<Coach> Coaches { get; set; }

        public virtual ICollection<GroupOfStudents> GroupOfStudents { get; set; }
    }
}
