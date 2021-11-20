using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoContracts.ModelsDTO;

namespace ZRdemoBll.Interfaces
{
    public interface ICoachService
    {
        Task<IEnumerable<CoachDTO>> GetCoaches();

        Task<CoachDTO> GetCoach(int id);

        void Add(CoachDTO coachDTO);

        void Edit(int id, CoachDTO coachDTO);

        void Delete(int id);
    }
}
