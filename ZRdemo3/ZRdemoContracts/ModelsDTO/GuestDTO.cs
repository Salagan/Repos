using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoContracts.Enum;

namespace ZRdemoContracts.ModelsDTO
{
    public class GuestDTO
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        public Belts Belt { get; set; }

        [Display(Name = "School name")]
        public string SchoolName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required]
        public string Email { get; set; }

    }
}
