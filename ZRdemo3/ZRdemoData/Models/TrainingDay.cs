using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class TrainingDay
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public bool IsHolliday { get; set; }

        public virtual ICollection<Gym> Gyms { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }

    }
}
