using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoBll.ModelsDTO;

namespace ZRdemoBll.Interfaces
{
    public interface ITrainingService
    {
        Task<IEnumerable<TrainingDTO>> GetTrainings();

        Task<TrainingDTO> GetTraining(int id);

        void Add(TrainingDTO trainingDTO);

        void Edit(int id, TrainingDTO trainingDTO);

        void Delete(int id);
    }
}
