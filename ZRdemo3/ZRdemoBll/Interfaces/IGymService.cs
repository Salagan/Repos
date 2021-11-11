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

        void Dispose();
    }
}
