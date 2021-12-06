﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZRdemoContracts.ModelsDTO
{
    public class GymDTO
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public bool IsAvailable { get; set; }

        public string WorkingHours { get; set; }

        public List<TrainingDTO> Trainings { get; set; }
    }
}
