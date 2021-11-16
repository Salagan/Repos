using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoBll.ModelsDTO;

namespace ZRdemoBll.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetStudents();

        Task<StudentDTO> GetStudent(int id);

        void Add(StudentDTO studentDTO);

        void Edit(int id, StudentDTO studentDTO);

        void Delete(int id);
    }
}
