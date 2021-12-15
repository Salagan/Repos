using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using ZRdemoContracts.ModelsDTO;

namespace ZRWeb.HttpClients
{
    public interface ICoachApi
    {
        [Get("/api/coaches")]
        Task<IEnumerable<CoachDTO>> GetCoaches();

        [Get("/api/coaches/{id}")]
        Task<CoachDTO> GetCoach(int id);

        [Put("/api/coaches/{id}")]
        Task Edit(int id, CoachDTO coach);

        [Post("/api/coaches")]
        Task Add(CoachDTO coach);

        [Delete("/api/coaches/{id}")]
        Task Delete(int id);

        [Get("/api/coaches/email")]
        Task<CoachDTO> FindCoachUserAsync(string email, string password);
    }
}
