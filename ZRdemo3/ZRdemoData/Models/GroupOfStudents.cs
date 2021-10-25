﻿using System;
using System.Collections.Generic;
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
        }

        public int Id { get; set; }

        public int CoachId { get; set; }

        public int GymId { get; set; }

        public GroupType GroupType { get; set; }

        public string GroupAge { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<TrainingDay> TrainingDays { get; set; }
    }
}
