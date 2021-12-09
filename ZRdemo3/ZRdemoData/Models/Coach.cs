using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoData.Enums;

namespace ZRdemoData.Models
{
    public class Coach
    {
        public Coach()
        {
            this.Trainings = new HashSet<Training>();
        }

        public int CoachId { get; set; }

        [Display(Name ="First Name")]
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Phone(ErrorMessage = "The phone number is not valid")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public Gender Gender { get; set; }

        [Display(Name ="Working")]
        public bool IsWorking { get; set; }

        public Belts Belt { get; set; }

        public ICollection<Training> Trainings { get; set; }
    }
}
