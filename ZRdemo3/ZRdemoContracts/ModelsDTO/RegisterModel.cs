using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoContracts.ModelsDTO
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Enter your Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "password doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}
