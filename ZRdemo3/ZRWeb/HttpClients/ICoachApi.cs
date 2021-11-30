using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using ZRdemoContracts.ModelsDTO;

namespace ZRWeb.HttpClients
{
    interface ICoachApi
    {
        [Get("/api/coaches")]
        Task<IEnumerable<CoachDTO>> GetCoaches();

        [Get("/api/coaches/{id}")]
        Task<CoachDTO> GetCoach(int id);
    }
}
