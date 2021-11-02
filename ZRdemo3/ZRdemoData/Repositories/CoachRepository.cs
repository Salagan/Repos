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
    public class CoachRepository : GenericRepository<Coach>, ICoachRepository
    {
        public CoachRepository(ZRdemoContext context)
            : base(context)
        {
        }

        public new Coach GetById(int id)
        {
            return this._context.Coaches
                .Where(c => c.CoachId == id)
                .Include(t => t.CoachTrainingDays)
                    .ThenInclude(ctr => ctr.TrainingDay)
                        .ThenInclude(tr => tr.Trainings)
                .FirstOrDefault();
        }

        public new IEnumerable<Coach> GetAll()
        {
            return this._context.Coaches
                .Include(t => t.CoachTrainingDays)
                .ToList();
        }
    }
}
