using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class Announcement
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Theme { get; set; }

        public DateTime Date { get; set; }

        public Coach Coach { get; set; }
    }
}
