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
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<StudentDTO>> GetStudents()
        {
            var students = await this._unitOfWork.Students.GetAll();

            var studentsDTO = this._mapper.Map<IEnumerable<StudentDTO>>(students);

            return studentsDTO;
        }

        public async Task<StudentDTO> GetStudent(int id)
        {
            var student = await this._unitOfWork.Students.GetById(id);

            if (student == null)
            {
                throw new Exception("Not found");
            }

            var studentDTO = this._mapper.Map<StudentDTO>(student);

            return studentDTO;
        }

        public async void Add(StudentDTO studentDTO)
        {
            var studentEx = this._unitOfWork.Students.FindAsync(s => s.FirstName == studentDTO.FirstName,
                                                                s => s.LastName == studentDTO.LastName,
                                                                s => s.Age == studentDTO.Age);
            if (studentEx != null)
            {
                throw new Exception("Allready exist");
            }

            var student = this._mapper.Map<Student>(studentDTO);

            this._unitOfWork.Students.Add(student);

            await this._unitOfWork.Complete();
        }

        public async void Edit(int id, StudentDTO studentDTO)
        {
            var student = await this._unitOfWork.Students.GetById(id);

            if (student == null)
            {
                throw new Exception("Not found!");
            }

            if (studentDTO.StudentId != id)
            {
                studentDTO.StudentId = id;
            }

            this._mapper.Map(studentDTO, student);

            this._unitOfWork.Students.Update(student);

            await this._unitOfWork.Complete();
        }

        public async void Delete(int id)
        {
            var student = await this._unitOfWork.Students.GetById(id);

            if (student == null)
            {
                throw new Exception("Not found!");
            }

            this._unitOfWork.Students.Remove(student);

            await this._unitOfWork.Complete();
        }
    }
}
