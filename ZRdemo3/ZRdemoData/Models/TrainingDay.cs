using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class TrainingDay
    {
        public TrainingDay()
        {
            this.GroupOfStudentsTrainingDay = new HashSet<GroupOfStudentsTrainingDay>();
            this.CoacheTrainingDay = new HashSet<CoachTrainingDay>();
            this.GymTrainingDays = new HashSet<GymTrainingDay>();
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public bool IsHolliday { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }

        public virtual ICollection<GymTrainingDay> GymTrainingDays { get; set; }

        public virtual ICollection<CoachTrainingDay> CoacheTrainingDay { get; set; }

        public virtual ICollection<GroupOfStudentsTrainingDay> GroupOfStudentsTrainingDay { get; set; }
    }
}
