using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoContracts.ModelsDTO;

namespace ZRdemoBll.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupOfStudentsDTO>> GetGroups();

        Task<GroupOfStudentsDTO> GetGroup(int id);

        void Add(GroupOfStudentsDTO groupOfStudentsDTO);

        void Edit(int id, GroupOfStudentsDTO groupOfStudentsDTO);

        void Delete(int id);
    }
}
