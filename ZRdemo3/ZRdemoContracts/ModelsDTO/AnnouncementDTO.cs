using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoContracts.ModelsDTO
{
    public class AnnouncementDTO
    {
        public int Id { get; set; }

        [Display(Name = "Announcement")]
        [MaxLength(500)]
        [Required]
        public string Text { get; set; }

        [MaxLength(50)]
        [Required]
        public string Theme { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public CoachDTO Coach { get; set; }
    }
}
