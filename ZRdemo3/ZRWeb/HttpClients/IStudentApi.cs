using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using ZRdemoContracts.ModelsDTO;

namespace ZRWeb.HttpClients
{
    interface IStudentApi
    {
        [Get("/api/students")]
        Task<IEnumerable<StudentDTO>> GetStudents();

        [Get("/api/students/{id}")]
        Task<StudentDTO> GetStudent(int id);
    }
}
