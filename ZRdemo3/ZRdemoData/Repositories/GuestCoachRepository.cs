using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;

namespace ZRdemoData.Repositories
{
    public class GuestCoachRepository : GenericRepository<GuestCoach>, IGuestCoachRepository
    {
        public GuestCoachRepository(ZRdemoContext context)
            : base(context)
        {
        }
    }
}
