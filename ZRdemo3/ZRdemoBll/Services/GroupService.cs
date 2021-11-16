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
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<GroupOfStudentsDTO>> GetGroups()
        {
            var groups = await this._unitOfWork.GroupsOfStudents.GetAll();

            var groupsDTO = this._mapper.Map<IEnumerable<GroupOfStudentsDTO>>(groups);

            return groupsDTO;
        }

        public async Task<GroupOfStudentsDTO> GetGroup(int id)
        {
            var group = await this._unitOfWork.GroupsOfStudents.GetById(id);
            if (group == null)
            {
                throw new Exception("Not found");
            }

            var groupDTO = this._mapper.Map<GroupOfStudentsDTO>(group);

            return groupDTO;
        }

        public async void Add(GroupOfStudentsDTO groupOfStudentsDTO)
        {
            var groupEx = this._unitOfWork.GroupsOfStudents.Find(g => g.GroupType.ToString() == groupOfStudentsDTO.GroupType.ToString())
                                                 .Where(g => g.GroupAge == groupOfStudentsDTO.GroupAge)
                                                 .FirstOrDefault();
            if (groupEx != null)
            {
                throw new Exception("Allready exist");
            }

            var group = this._mapper.Map<GroupOfStudents>(groupOfStudentsDTO);

            this._unitOfWork.GroupsOfStudents.Add(group);
            await this._unitOfWork.Complete();
        }

        public async void Edit(int id, GroupOfStudentsDTO groupOfStudentsDTO)
        {
            var group = await this._unitOfWork.GroupsOfStudents.GetById(id);

            if (group == null)
            {
                throw new Exception("Not found!");
            }

            if (groupOfStudentsDTO.Id != id)
            {
                groupOfStudentsDTO.Id = id;
            }

            this._mapper.Map(groupOfStudentsDTO, group);

            this._unitOfWork.GroupsOfStudents.Update(group);

            await this._unitOfWork.Complete();
        }

        public async void Delete(int id)
        {
            var group = await this._unitOfWork.GroupsOfStudents.GetById(id);

            if (group == null)
            {
                throw new Exception("Not found!");
            }

            this._unitOfWork.GroupsOfStudents.Remove(group);

            await this._unitOfWork.Complete();
        }
    }
}
