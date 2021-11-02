﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Models
{
    public class Coach
    {
        public Coach()
        {
            this.CoachTrainingDays = new HashSet<CoachTrainingDay>();
        }

        public int CoachId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }

        public bool IsWorking { get; set; }

        public ICollection<CoachTrainingDay> CoachTrainingDays { get; set; }
    }
}
