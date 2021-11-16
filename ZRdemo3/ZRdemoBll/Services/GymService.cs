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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GymService (IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<GymDTO>> GetGyms()
        {
            var gyms = await this._unitOfWork.Gyms.GetAll();
            return this._mapper.Map<IEnumerable<Gym>, IEnumerable<GymDTO>>(gyms);
        }

        public async Task<GymDTO> GetGymById(int id)
        {
            var gym = await this._unitOfWork.Gyms.GetById(id);
            return this._mapper.Map<GymDTO>(gym);
        }

        public async void Add(GymDTO gymDTO)
        {
           if (gymDTO == null)
           {
                throw new Exception("Invalid object");
           }

            // method to check if object exact same object is already exist
           if (this._unitOfWork.Gyms.Find(g => g.Address.Trim().ToLower() == gymDTO.Address.Trim().ToLower()) != null)
           {
                throw new Exception("Gym allready exist");
           }

           var gym = this._mapper.Map<Gym>(gymDTO);

           this._unitOfWork.Gyms.Add(gym);
           await this._unitOfWork.Complete();
        }

        public async Task<GymDTO> Edit(int id, GymDTO gymDTO)
        {
            var gym = await this._unitOfWork.Gyms.GetById(id);

            if (gym == null)
            {
                throw new Exception("There is no such gym");
            }

            if (gymDTO == null)
            {
                throw new Exception("Invalid object");
            }

            this._mapper.Map(gymDTO, gym);

            this._unitOfWork.Gyms.Update(gym);

            await this._unitOfWork.Complete();

            return gymDTO;
        }

        public async void Delete(int id)
        {
            var gym = await this._unitOfWork.Gyms.GetById(id);

            if (gym == null)
            {
                throw new Exception("There is no such gym");
            }

            this._unitOfWork.Gyms.Remove(gym);

            await this._unitOfWork.Complete();
        }
    }
}
