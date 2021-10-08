using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
