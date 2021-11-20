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
    public class GuestService : IGuestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GuestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<GuestDTO>> GetGuests()
        {
            var guests = await this._unitOfWork.Guests.GetAll();

            var guestsDTO = this._mapper.Map<IEnumerable<GuestDTO>>(guests);

            return guestsDTO;
        }

        public async Task<GuestDTO> GetGuest(int id)
        {
            var guest = await this._unitOfWork.Guests.GetById(id);

            if (guest == null)
            {
                throw new Exception("Not found!");
            }

            var guestDTO = this._mapper.Map<GuestDTO>(guest);

            return guestDTO;
        }

        public async void Add(GuestDTO guestDTO)
        {
            var guestEx = this._unitOfWork.Guests.FindAsync(g => g.Name == guestDTO.Name,
                                                            g => g.LastName == guestDTO.LastName);

            if (guestEx != null)
            {
                throw new Exception("Allready exist");
            }

            var guest = this._mapper.Map<Guest>(guestDTO);

            this._unitOfWork.Guests.Add(guest);

            await this._unitOfWork.Complete();
        }

        public async void Edit(int id, GuestDTO guestDTO)
        {
            var guest = await this._unitOfWork.Guests.GetById(id);

            if (guest == null)
            {
                throw new Exception("Not found!");
            }

            if (guestDTO.Id != id)
            {
                guestDTO.Id = id;
            }

            this._mapper.Map(guestDTO, guest);

            this._unitOfWork.Guests.Update(guest);

            await this._unitOfWork.Complete();
        }

        public async void Delete(int id)
        {
            var guest = await this._unitOfWork.Guests.GetById(id);

            if (guest == null)
            {
                throw new Exception("Not found!");
            }

            this._unitOfWork.Guests.Remove(guest);

            await this._unitOfWork.Complete();
        }
    }
}
