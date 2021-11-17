﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZRdemoBll.Interfaces;
using ZRdemoBll.ModelsDTO;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;

namespace ZRdemoBll.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TrainingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TrainingDTO>> GetTrainings()
        {
            var trainings = await this._unitOfWork.Trainings.GetAll();

            var trainingsDTO = this._mapper.Map<IEnumerable<TrainingDTO>>(trainings);

            return trainingsDTO;
        }

        public async Task<TrainingDTO> GetTraining(int id)
        {
            var training = await this._unitOfWork.Trainings.GetById(id);

            if (training == null)
            {
                throw new Exception("Not found");
            }

            var trainingDTO = this._mapper.Map<TrainingDTO>(training);

            return trainingDTO;
        }

        public async void Add(TrainingDTO trainingDTO)
        {
            var trainingEx = await this._unitOfWork.Trainings.FindAsync(t => t.TimeStart == trainingDTO.TimeStart,
                                                                        t => t.GymId == trainingDTO.GymId);
            if (trainingEx != null)
            {
                throw new Exception("Alredy exist");
            }

            var training = this._mapper.Map<Training>(trainingDTO);

            this._unitOfWork.Trainings.Add(training);

            await this._unitOfWork.Complete();
        }

        public async void Edit(int id, TrainingDTO trainingDTO)
        {
            var training = await this._unitOfWork.Trainings.GetById(id);

            if (training == null)
            {
                throw new Exception("Not found");
            }

            if (trainingDTO.Id != id)
            {
                trainingDTO.Id = id;
            }

            this._mapper.Map(trainingDTO, training);

            this._unitOfWork.Trainings.Update(training);

            await this._unitOfWork.Complete();
        }

        public async void Delete(int id)
        {
            var training = await this._unitOfWork.Trainings.GetById(id);

            if (training == null)
            {
                throw new Exception("Not found");
            }

            this._unitOfWork.Trainings.Remove(training);

            await this._unitOfWork.Complete();
        }
    }
}
