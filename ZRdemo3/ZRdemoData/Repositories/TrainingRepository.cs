﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;

namespace ZRdemoData.Repositories
{
    public class TrainingRepository : GenericRepository<Training>, ITrainingRepository
    {
        public TrainingRepository(ZRdemoContext context)
            : base(context)
        {
        }

        public async override Task<Training> GetById(int id)
        {
            return await this._context.Trainings
                .Where(t => t.Id == id)
                .Include(t => t.Coach)
                .Include(t => t.GroupOfStudents)
                .FirstOrDefaultAsync();
        }
    }
}
