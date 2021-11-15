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
        private readonly IUnitOfWork Database;
        private readonly IMapper _mapper;

        public GymService (IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.Database = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<GymDTO>> GetGyms()
        {
            var gyms = await this.Database.Gyms.GetAll();
            return this._mapper.Map<IEnumerable<Gym>, IEnumerable<GymDTO>>(gyms);
        }

        public async Task<GymDTO> GetGymById(int id)
        {
            var gym = await this.Database.Gyms.GetById(id);
            return this._mapper.Map<GymDTO>(gym);
        }

        public async void Add(GymDTO gymDTO)
        {
           if (gymDTO == null)
           {
                throw new Exception("Invalid object");
           }

            // method to check if object exact same object is already exist
           if (this.Database.Gyms.Find(g => g.Address.Trim().ToLower() == gymDTO.Address.Trim().ToLower()) != null)
           {
                throw new Exception("Gym allready exist");
           }

           var gym = this._mapper.Map<Gym>(gymDTO);

           this.Database.Gyms.Add(gym);
           await this.Database.Complete();
        }

        public async Task<GymDTO> Edit(int id, GymDTO gymDTO)
        {
            var gym = await this.Database.Gyms.GetById(id);

            if (gym == null)
            {
                throw new Exception("There is no such gym");
            }

            if (gymDTO == null)
            {
                throw new Exception("Invalid object");
            }

            this._mapper.Map(gymDTO, gym);

            this.Database.Gyms.Update(gym);

            await this.Database.Complete();

            return gymDTO;
        }

        public async void Delete(int id)
        {
            var gym = await this.Database.Gyms.GetById(id);

            if (gym == null)
            {
                throw new Exception("There is no such gym");
            }

            this.Database.Gyms.Remove(gym);

            await this.Database.Complete();
        }

        public void Dispose()
        {
            this.Database.Dispose();
        }
    }
}
