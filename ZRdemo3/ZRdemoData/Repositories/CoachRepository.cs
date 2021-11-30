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

        public async override Task<Coach> GetById(int id)
        {
            return await this._context.Coaches
                .Where(c => c.CoachId == id)
                .Include(t => t.Trainings)
                .FirstOrDefaultAsync();
        }
    }
}
