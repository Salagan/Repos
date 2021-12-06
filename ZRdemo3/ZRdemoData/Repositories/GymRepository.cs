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
    public class GymRepository : GenericRepository<Gym>, IGymRepository
    {
        public GymRepository(ZRdemoContext context)
            : base(context)
        {
        }

        public async override Task<Gym> GetById(int id)
        {
            return await this._context.Gyms
                .Where(g => g.Id == id)
                .Include(g => g.Trainings)
                .FirstOrDefaultAsync();
        }

        public async override Task<IEnumerable<Gym>> GetAll()
        {
            return await this._context.Gyms
                .Include(g => g.Trainings)
                .ToListAsync();
        }
    }
}
