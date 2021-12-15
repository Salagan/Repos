using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using ZRdemoContracts.ModelsDTO;

namespace ZRWeb.HttpClients
{
    public interface IAnnouncementApi
    {
        [Get("/api/announcements")]
        Task<IEnumerable<AnnouncementDTO>> GetAll();

        [Get("/api/announcements/{id}")]
        Task<AnnouncementDTO> GetAd(int id);

        [Put("/api/announcements/{id}")]
        Task Edit(int id, AnnouncementDTO announcement);

        [Post("/api/announcements")]
        Task Add(AnnouncementDTO announcement);

        [Delete("/api/announcements/{id}")]
        Task Delete(int id);
    }
}
