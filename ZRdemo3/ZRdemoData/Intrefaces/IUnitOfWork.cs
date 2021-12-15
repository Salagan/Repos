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

        IStudentRepository Students { get; }

        ITrainingRepository Trainings { get; }

        IGuestRepository Guests { get; }

        IAnnouncemetRepository Announcemet { get; }

        Task<int> Complete();
    }
}
