using System;
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
    public class TrainingDaysController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainingDaysController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/<TrainingDayController>
        [HttpGet]
        public ActionResult<IEnumerable<TrainingDayRepository>> GetAll()
        {
            var trainingDays = this._unitOfWork.TrainingDays.GetAll();
            return this.Ok(trainingDays);
        }

        // GET api/<TrainingDayController>/5
        [HttpGet("{id}")]
        public ActionResult<TrainingDayRepository> GetById(int id)
        {
            var trainingDay = this._unitOfWork.TrainingDays.GetById(id);
            if (trainingDay == null)
            {
                return this.BadRequest();
            }

            return this.Ok(trainingDay);
        }

        // POST api/<TrainingDayController>
        [HttpPost]
        public ActionResult<TrainingDayRepository> Add([FromForm] TrainingDay trainingDay)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._unitOfWork.TrainingDays.Add(trainingDay);
            this._unitOfWork.Complete();

            return this.RedirectToAction("GetAll");
        }

        // PUT api/<TrainingDayController>/5
        [HttpPut("{id}")]
        public ActionResult<TrainingDayRepository> Update(int id, [FromForm] TrainingDay trainingDay)
        {
            if (id != trainingDay.Id)
            {
                return this.BadRequest();
            }

            try
            {
                this._unitOfWork.TrainingDays.Update(trainingDay);
                this._unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction("GetAll");
        }

        // DELETE api/<TrainingDayController>/5
        [HttpDelete("{id}")]
        public ActionResult<TrainingDayRepository> Delete(int id)
        {
            var trainingDay = this._unitOfWork.TrainingDays.GetById(id);

            if (trainingDay == null)
            {
                return this.BadRequest();
            }

            this._unitOfWork.TrainingDays.Remove(trainingDay);
            this._unitOfWork.Complete();

            return this.RedirectToAction("GetAll");
        }
    }
}
