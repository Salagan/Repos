using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZRdemoBll.Interfaces;
using ZRdemoContracts.ModelsDTO;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;

namespace ZRdemoBll.Services
{
    public class GymService : IGymService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GymService(IUnitOfWork unitOfWork, IMapper mapper)
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

        public async Task Add(GymDTO gymDTO)
        {
            // method to check if object exact same object is already exist
            // if (this._unitOfWork.Gyms.FindOneAsync(g => g.Address.Trim().ToLower() == gymDTO.Address.Trim().ToLower()) != null)
            var gymEx = await this._unitOfWork.Gyms.FindOneAsync(g => g.Address.Trim().ToLower() == gymDTO.Address.Trim().ToLower());

            if (gymEx != null)
            {
                throw new Exception("Gym allready exist");
            }

            var gym = this._mapper.Map<Gym>(gymDTO);

            this._unitOfWork.Gyms.Add(gym);
            await this._unitOfWork.Complete();
        }

        public async Task Edit(int id, GymDTO gymDTO)
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
        }

        public async Task Delete(int id)
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
