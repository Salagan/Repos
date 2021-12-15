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

        Task Add(CoachDTO coachDTO);

        Task Edit(int id, CoachDTO coachDTO);

        Task Delete(int id);

        Task<CoachDTO> FindCoachUserAsync(string email, string password);
    }
}
