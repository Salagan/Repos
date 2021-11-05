using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;
using ZRdemoData.Repositories;

namespace ZRdemoData.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZRdemoContext _context;

        public UnitOfWork(ZRdemoContext context)
        {
            this._context = context;

            this.Coaches = new CoachRepository(this._context);

            this.GroupsOfStudents = new GroupOfStudentsRepository(this._context);

            this.Gyms = new GymRepository(this._context);

            this.Students = new StudentRepository(this._context);

            this.Trainings = new TrainingRepository(this._context);

            this.Guests = new GuestRepository(this._context);
        }

        public ICoachRepository Coaches { get; private set; }

        public IGroupOfStudentsRepository GroupsOfStudents { get; private set; }

        public IGymRepository Gyms { get; private set; }

        public IStudentRepository Students { get; private set; }

        public ITrainingRepository Trainings { get; private set; }

        public IGuestRepository Guests { get; private set; }

        public async Task<int> Complete()
        {
            return await this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
