using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoBll.ModelsDTO;

namespace ZRdemoBll.Interfaces
{
    public interface IGymService
    {
        Task<IEnumerable<GymDTO>> GetGyms();

        Task<GymDTO> GetGymById(int id);

        void Add(GymDTO gymDTO);

        Task<GymDTO> Edit(int id, GymDTO gymDTO);

        void Delete(int id);

        void Dispose();
    }
}
