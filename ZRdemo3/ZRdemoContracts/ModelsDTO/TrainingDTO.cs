using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [Display(Name = "Gym Id")]
        [Range(1, 100)]
        public int GymId { get; set; }

        [Required]
        [Display(Name = "Coach Id")]
        [Range(1, 100)]
        public int CoachId { get; set; }

        [Required]
        [Display(Name = "Group Id")]
        [Range(1, 100)]
        public int GroupOfStudentsId { get; set; }

        // entity properties
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start at")]
        public DateTime TimeStart { get; set; }

        [Required]
        public Uniform Uniform { get; set; }

        [Display(Name = "Type of training")]
        [Required]
        public TypeOfTraining TypeOfTraining { get; set; }

        public GymDTO Gym { get; set; }

        public CoachDTO Coach { get; set; }

        public GroupOfStudentsDTO GroupOfStudents { get; set; }
    }
}
