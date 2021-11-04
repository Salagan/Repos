using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public enum GroupType
    {
        AdultBeginers,
        AdultAdvance,
        Kids,
        Junior,
        Juvenile,
    }

    public class GroupOfStudents
    {
        public GroupOfStudents()
        {
            this.Students = new HashSet<Student>();
            this.Trainings = new HashSet<Training>();
        }

        public int Id { get; set; }

        public GroupType GroupType { get; set; }

        public string GroupAge { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }
    }
}
