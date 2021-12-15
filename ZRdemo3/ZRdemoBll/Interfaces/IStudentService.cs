using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoContracts.ModelsDTO;

namespace ZRdemoBll.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetStudents();

        Task<StudentDTO> GetStudent(int id);

        Task Add(StudentDTO studentDTO);

        Task Edit(int id, StudentDTO studentDTO);

        Task Delete(int id);

        Task<StudentDTO> FindStudentUserAsync(string email, string password);
    }
}
