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
    public class AnnouncementRepository : GenericRepository<Announcement>, IAnnouncemetRepository
    {
        public AnnouncementRepository(ZRdemoContext context)
            : base(context)
        {
        }

        public async override Task<IEnumerable<Announcement>> GetAll()
        {
            return await this._context.Announcements.ToListAsync();
        }

        public async override Task<Announcement> GetById(int id)
        {
            return await this._context.Announcements
                .Where(a => a.Id == id)
                .Include(a => a.Coach)
                .FirstOrDefaultAsync();
        }
    }
}
