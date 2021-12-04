using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using ZRdemoContracts.ModelsDTO;

namespace ZRWeb.HttpClients
{
    public interface IStudentApi
    {
        [Get("/api/students")]
        Task<IEnumerable<StudentDTO>> GetStudents();

        [Get("/api/students/{id}")]
        Task<StudentDTO> GetStudent(int id);

        [Post("/api/students")]
        Task AddStudent(StudentDTO studentDTO);

        [Put("/api/students/{id}")]
        Task Edit(int id, StudentDTO student);

        [Delete("/api/students/{id}")]
        Task Delete(int id);
    }
}
