using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoContracts.ModelsDTO;

namespace ZRdemoBll.Interfaces
{
    public interface IAnnouncementService
    {
        Task<IEnumerable<AnnouncementDTO>> GetAll();

        Task<AnnouncementDTO> GetOne(int id);

        Task Make(AnnouncementDTO announcement);

        Task Edit(int id, AnnouncementDTO announcement);

        Task Delete(int id);
    }
}
