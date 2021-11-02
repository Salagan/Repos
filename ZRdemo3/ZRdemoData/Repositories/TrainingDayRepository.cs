using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;

namespace ZRdemoData.Repositories
{
    public class TrainingDayRepository : GenericRepository<TrainingDay>, ITrainingDayRepository
    {
        public TrainingDayRepository(ZRdemoContext context)
            : base(context)
        {
        }

        public new IEnumerable<TrainingDay> GetAll()
        {
            return this._context.TrainingDays
                .Include(tr => tr.CoacheTrainingDay)
                .Include(tr => tr.GroupOfStudentsTrainingDay)
                .Include(tr => tr.GymTrainingDays)
                .ToList();
        }

        public new TrainingDay GetById(int id)
        {
            return this._context.TrainingDays
                .Where(tr => tr.Id == id)
                .Include(tr => tr.CoacheTrainingDay)
                    .ThenInclude(ctr => ctr.Coach)
                .Include(tr => tr.GroupOfStudentsTrainingDay)
                    .ThenInclude(gtr => gtr.GroupOfStudents)
                .Include(tr => tr.GymTrainingDays)
                    .ThenInclude(gt => gt.Gym)
                .FirstOrDefault();
        }
    }
}
