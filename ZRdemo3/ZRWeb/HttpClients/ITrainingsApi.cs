using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using ZRdemoContracts.ModelsDTO;

namespace ZRWeb.HttpClients
{
    public interface ITrainingsApi
    {
        [Get("/api/trainings")]
        Task<IEnumerable<TrainingDTO>> GetTrainings();

        [Get("/api/trainings/{id}")]
        Task<TrainingDTO> GetTraining(int id);

        [Put("/api/trainings/{id}")]
        Task Edit(int id, TrainingDTO training);

        [Post("/api/trainings")]
        Task Add(TrainingDTO training);

        [Delete("/api/trainings/{id}")]
        Task Delete(int id);
    }
}
