using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using ZRdemoBll.ModelsDTO;

namespace ZRWeb.HttpClients
{
    public interface IGymApi
    {
        [Get("/api/gyms/{id}")]
        Task<GymDTO> GetById(int id);
    }
}
