using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoContracts.Enum;

namespace ZRdemoContracts.ModelsDTO
{
    public class StudentDTO
    {
        public int StudentId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter valid int number of group")]
        public int? GroupOfStudentsId { get; set; }

        [Display(Name = "First Name")]
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

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public Gender Gender { get; set; }

        public bool Injury { get; set; }

        public Belts Belt { get; set; }

        public GroupOfStudentsDTO GroupOfStudentsDTO { get; set; }
    }
}
