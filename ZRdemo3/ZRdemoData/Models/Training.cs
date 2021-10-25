using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public enum TypeOfTraining
    {
        RegularTraining,
        Seminar,
        OpenMat,
        Personal,
    }

    public enum Uniform
    {
        Gi,
        NoGi,
    }

    public class Training
    {
        public int Id { get; set; }

        public int CoachId { get; set; }

        public int GymId { get; set; }

        public int TrainingDayId { get; set; }

        public int? CoachGuestId { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public Uniform Uniform { get; set; }

        public TypeOfTraining TypeOfTraining { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }
}
