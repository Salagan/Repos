using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoContracts.ModelsDTO;

namespace ZRdemoBll.Interfaces
{
    public interface IGymService
    {
        Task<IEnumerable<GymDTO>> GetGyms();

        Task<GymDTO> GetGymById(int id);

        Task Add(GymDTO gymDTO);

        Task Edit(int id, GymDTO gymDTO);

        Task Delete(int id);
    }
}
