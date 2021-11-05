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
    public class GroupOfStudentsRepository : GenericRepository<GroupOfStudents>, IGroupOfStudentsRepository
    {
        public GroupOfStudentsRepository(ZRdemoContext context)
            : base(context)
        {
        }

        public async override Task<IEnumerable<GroupOfStudents>> GetAll()
        {
            return await this._context.GroupOfStudents
                 .Include(g => g.Students)
                 .ToListAsync();
        }

        public async override Task<GroupOfStudents> GetById(int id)
        {
            return await this._context.GroupOfStudents
                .Where(g => g.Id == id)
                .Include(s => s.Students)
                .Include(t => t.Trainings)
                .FirstOrDefaultAsync();
        }
    }
}
