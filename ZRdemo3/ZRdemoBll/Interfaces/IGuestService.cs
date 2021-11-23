using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoContracts.ModelsDTO;

namespace ZRdemoBll.Interfaces
{
    public interface IGuestService
    {
        Task<IEnumerable<GuestDTO>> GetGuests();

        Task<GuestDTO> GetGuest(int id);

        Task Add(GuestDTO guestDTO);

        Task Edit(int id, GuestDTO guestDTO);

        Task Delete(int id);
    }
}
