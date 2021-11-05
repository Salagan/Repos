﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;
using ZRdemoData.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ZRdemo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainingsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/<TrainingsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingRepository>>> GetAll()
        {
            var trainings = await this._unitOfWork.Trainings.GetAll();
            return this.Ok(trainings);
        }

        // GET api/<TrainingsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingRepository>> GetById(int id)
        {
            var training = await this._unitOfWork.Trainings.GetById(id);
            if (training == null)
            {
                return this.BadRequest();
            }

            return this.Ok(training);
        }

        // POST api/<TrainingsController>
        [HttpPost]
        public async Task<ActionResult<TrainingRepository>> Add([FromBody] Training training)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._unitOfWork.Trainings.Add(training);
            await this._unitOfWork.Complete();
            return this.RedirectToAction("GetAll");
        }

        // PUT api/<TrainingsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TrainingRepository>> Update(int id, [FromForm] Training training)
        {
            if (id != training.Id)
            {
                return this.BadRequest();
            }

            try
            {
                this._unitOfWork.Trainings.Update(training);
                await this._unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction("GetAll");
        }

        // DELETE api/<TrainingsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrainingRepository>> Delete(int id)
        {
            var training = await this._unitOfWork.Trainings.GetById(id);

            if (training == null)
            {
                return this.BadRequest();
            }

            this._unitOfWork.Trainings.Remove(training);
            await this._unitOfWork.Complete();

            return this.RedirectToAction("GetAll");
        }
    }
}
