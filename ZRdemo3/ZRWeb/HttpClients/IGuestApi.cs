using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using ZRdemoContracts.ModelsDTO;

namespace ZRWeb.HttpClients
{
    public interface IGuestApi
    {
        [Get("/api/guests")]
        Task<IEnumerable<GuestDTO>> GetGuests();

        [Get("/api/guests/{id}")]
        Task<GuestDTO> GetGuest(int id);

        [Post("/api/guests/{id}")]
        Task Edit(int id, GuestDTO guest);

        [Post("/api/guests")]
        Task Add(GuestDTO guest);

        [Delete("/api/guests/{id}")]
        Task Delete(int id);
    }
}
