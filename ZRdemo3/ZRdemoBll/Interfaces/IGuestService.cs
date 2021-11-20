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

        void Add(GuestDTO guestDTO);

        void Edit(int id, GuestDTO guestDTO);

        void Delete(int id);
    }
}
