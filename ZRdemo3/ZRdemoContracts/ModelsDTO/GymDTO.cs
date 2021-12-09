using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ZRdemoContracts.ModelsDTO
{
    public class GymDTO
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }
        
        public bool IsAvailable { get; set; }

        [Required]
        public string WorkingHours { get; set; }
    }
}
