using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoContracts.ModelsDTO;

namespace ZRdemoBll.Interfaces
{
    public interface ITrainingService
    {
        Task<IEnumerable<TrainingDTO>> GetTrainings();

        Task<TrainingDTO> GetTraining(int id);

        Task Add(TrainingDTO trainingDTO);

        Task Edit(int id, TrainingDTO trainingDTO);

        Task Delete(int id);
    }
}
