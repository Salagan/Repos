using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using ZRdemoContracts.ModelsDTO;

namespace ZRWeb.HttpClients
{
    public interface IGroupsApi
    {
        [Get("/api/groupOfStudents")]
        Task<IEnumerable<GroupOfStudentsDTO>> GetGroups();

        [Get("/api/groupOfStudents/{id}")]
        Task<GroupOfStudentsDTO> GetGroup(int id);

        [Put("/api/groupofstudents/{id}")]
        Task Edit(int id, GroupOfStudentsDTO group);

        [Post("/api/groupofstudents/")]
        Task Add(GroupOfStudentsDTO group);

        [Delete("/api/groupofstudents/{id}")]
        Task Delete(int id);
    }
}
