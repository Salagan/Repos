using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class Coach
    {
        public Coach()
        {
            this.TrainingDays = new HashSet<TrainingDay>();
        }

        public int Id { get; set; }

        public MemberOfTheTeam Member { get; set; }

        public bool IsWorking { get; set; }

        public virtual ICollection<TrainingDay> TrainingDays { get; set; }

        public virtual ICollection<GroupOfStudents> GroupOfStudents { get; set; }

    }
}
