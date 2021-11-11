using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZRdemoBll.Interfaces;
using ZRdemoBll.ModelsDTO;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;

namespace ZRdemoBll.Services
{
    public class GymService : IGymService
    {
        IUnitOfWork Database { get; set; }

        public GymService (IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public async Task<IEnumerable<GymDTO>> GetGyms()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Gym, GymDTO>()).CreateMapper();
            var gyms = await Database.Gyms.GetAll();
            return mapper.Map<IEnumerable<Gym>, IEnumerable<GymDTO>>(gyms);
        }
        
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
