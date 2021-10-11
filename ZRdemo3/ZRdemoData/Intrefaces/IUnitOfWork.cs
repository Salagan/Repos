using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemoData.Intrefaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICoachRepository Coaches { get; }

        IGroupOfStudentsRepository GroupsOfStudents { get; }

        IGymRepository Gyms { get; }

        IMemberRepository Members { get; }

        IStudentRepository Students { get; }

        ITrainingDayRepository TrainingDays { get; }

        ITrainingRepository Trainings { get; }

        int Complete();
    }
}
