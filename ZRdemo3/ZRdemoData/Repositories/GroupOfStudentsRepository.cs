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

        public override IEnumerable<GroupOfStudents> GetAll()
        {
            return this._context.GroupOfStudents
                 .Include(g => g.Students)
                 .ToList();
        }

        public override GroupOfStudents GetById(int id)
        {
            return this._context.GroupOfStudents
                .Where(g => g.Id == id)
                .Include(s => s.Students)
                .Include(t => t.Trainings)
                .FirstOrDefault();
        }
    }
}
