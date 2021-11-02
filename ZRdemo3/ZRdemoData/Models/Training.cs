using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        // keys
        [ForeignKey("TrainingDay")]
        public int TrainingDayId { get; set; }

        public int? GuestCoachId { get; set; }

        // entity properties
        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public Uniform Uniform { get; set; }

        public TypeOfTraining TypeOfTraining { get; set; }

        // navigation properties
        public virtual TrainingDay TrainingDay { get; set; }

        public virtual GuestCoach GuestCoach { get; set; }

        public virtual ICollection<GuestTraining> GuestTrainings { get; set; }
    }
}
