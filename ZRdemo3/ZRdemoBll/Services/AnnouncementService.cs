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
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public AnnouncementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;

            this._mapper = mapper;
        }

        public async Task<IEnumerable<AnnouncementDTO>> GetAll()
        {
            var announs = await this._unitOfWork.Announcemet.GetAll();

            var advert = this._mapper.Map<IEnumerable<AnnouncementDTO>>(announs);

            return advert;
        }

        public async Task<AnnouncementDTO> GetOne(int id)
        {
            var announ = await this._unitOfWork.Announcemet.GetById(id);
            if (announ == null)
            {
                throw new Exception("Not found");
            }

            var advert = this._mapper.Map<AnnouncementDTO>(announ);

            return advert;
        }

        public async Task Make(AnnouncementDTO announcement)
        {
            var advert = this._mapper.Map<Announcement>(announcement);

            this._unitOfWork.Announcemet.Add(advert);

            await this._unitOfWork.Complete();
        }

        public async Task Edit(int id, AnnouncementDTO announcement)
        {
            var announ = await this._unitOfWork.Announcemet.GetById(id);
            if (announ == null)
            {
                throw new Exception("Not found");
            }

            if (announcement.Id != id)
            {
                announcement.Id = id;
            }

            this._mapper.Map(announcement, announ);

            this._unitOfWork.Announcemet.Update(announ);

            await this._unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var announ = await this._unitOfWork.Announcemet.GetById(id);
            if (announ == null)
            {
                throw new Exception("Not found");
            }

            this._unitOfWork.Announcemet.Remove(announ);

            await this._unitOfWork.Complete();
        }
    }
}
