using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoData.Enums;

namespace ZRdemoData.Models
{
    public class Training
    {
        public int Id { get; set; }

        // keys
        [ForeignKey("GymId")]
        public int GymId { get; set; }

        [ForeignKey("Coachid")]
        public int CoachId { get; set; }

        [ForeignKey("GroupOfStudentsId")]
        public int GroupOfStudentsId { get; set; }

        // entity properties
        public DateTime TimeStart { get; set; }

        public Uniform Uniform { get; set; }

        public TypeOfTraining TypeOfTraining { get; set; }

        // navigation properties
        public virtual Gym Gym { get; set; }

        public virtual Coach Coach { get; set; }

        public virtual GroupOfStudents GroupOfStudents { get; set; }

        public virtual ICollection<GuestTraining> GuestTrainigs { get; set; }
    }
}
