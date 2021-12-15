using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZRdemoBll.Interfaces;
using ZRdemoContracts.ModelsDTO;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;

namespace ZRdemoBll.Services
{
    public class CoachService : ICoachService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CoachService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<CoachDTO>> GetCoaches()
        {
            var coaches = await this._unitOfWork.Coaches.GetAll();

            var coachesDTO = this._mapper.Map<IEnumerable<CoachDTO>>(coaches);

            return coachesDTO;
        }

        public async Task<CoachDTO> GetCoach(int id)
        {
            var coach = await this._unitOfWork.Coaches.GetById(id);
            if (coach == null)
            {
                throw new Exception("Not found");
            }

            var coachDTO = this._mapper.Map<CoachDTO>(coach);

            return coachDTO;
        }

        public async Task Add(CoachDTO coachDTO)
        {
            // var coachEx = this._unitOfWork.Coaches.FindOneAsync(c => c.FirstName == coachDTO.FirstName,
            //                                                 c => c.LastName == coachDTO.LastName);
            var coachEx = await this._unitOfWork.Coaches.FindOneAsync(c => c.FirstName == coachDTO.FirstName && c.LastName == coachDTO.LastName);

            if (coachEx != null)
            {
                throw new Exception("Allready exist");
            }

            var coach = this._mapper.Map<Coach>(coachDTO);

            this._unitOfWork.Coaches.Add(coach);

            await this._unitOfWork.Complete();
        }

        public async Task Edit(int id, CoachDTO coachDTO)
        {
            var coach = await this._unitOfWork.Coaches.GetById(id);

            if (coach == null)
            {
                throw new Exception("Not found!");
            }

            if (coachDTO.CoachId != id)
            {
                coachDTO.CoachId = id;
            }

            this._mapper.Map(coachDTO, coach);

            this._unitOfWork.Coaches.Update(coach);

            await this._unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var coach = await this._unitOfWork.Coaches.GetById(id);

            if (coach == null)
            {
                throw new Exception("Not found!");
            }

            this._unitOfWork.Coaches.Remove(coach);

            await this._unitOfWork.Complete();
        }

        public async Task<CoachDTO> FindCoachUserAsync(string email, string password)
        {
            var coach = await this._unitOfWork.Coaches.FindOneAsync(c => c.Email == email && c.Password == password);

            var c = this._mapper.Map<CoachDTO>(coach);

            return c;
        }
    }
}
