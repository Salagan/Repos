using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;

namespace ZRdemoData.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ZRdemoContext context)
            : base(context)
        {
        }

        public new IEnumerable<Student> GetAll()
        {
            return this._context.Students
                .Include(g => g.GroupOfStudents)
                .ToList();
        }

        public new Student GetById(int id)
        {
            return this._context.Students
                .Where(s => s.StudentId == id)
                .Include(g => g.GroupOfStudents)
                    .ThenInclude(t => t.TrainingDays)
                .FirstOrDefault();
        }
    }
}
