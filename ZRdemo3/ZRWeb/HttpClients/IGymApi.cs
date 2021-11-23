using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using ZRdemoContracts.ModelsDTO;

namespace ZRWeb.HttpClients
{
    public interface IGymApi
    {
        [Get("/api/gyms/{id}")]
        Task<GymDTO> GetById(int id);

        [Get("/api/gyms")]
        Task<IEnumerable<GymDTO>> GetGyms();

        [Post("/api/gyms/{id}")]
        Task Edit(int id, GymDTO gymDTO);

        [Post("/api/gyms")]
        Task Create(GymDTO gymDTO);

        [Delete("/api/gyms/{id}")]
        Task Delete(int id);
    }
}
