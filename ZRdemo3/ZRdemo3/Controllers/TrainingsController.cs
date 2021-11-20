using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZRdemoBll.Interfaces;
using ZRdemoContracts.ModelsDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ZRdemo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly ITrainingService _trainigService;

        public TrainingsController(ITrainingService trainingService)
        {
            this._trainigService = trainingService;
        }

        // GET: api/<TrainingsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingDTO>>> GetAll()
        {
            var trainings = await this._trainigService.GetTrainings();
            return this.Ok(trainings);
        }

        // GET api/<TrainingsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingDTO>> GetById(int id)
        {
            var training = await this._trainigService.GetTraining(id);

            return this.Ok(training);
        }

        // POST api/<TrainingsController>
        [HttpPost]
        public ActionResult<TrainingDTO> Add([FromBody] TrainingDTO trainingDTO)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._trainigService.Add(trainingDTO);

            return this.RedirectToAction("GetAll");
        }

        // PUT api/<TrainingsController>/5
        [HttpPut("{id}")]
        public ActionResult<TrainingDTO> Update(int id, [FromForm] TrainingDTO trainingDTO)
        {
            if (id != trainingDTO.Id)
            {
                return this.BadRequest();
            }

            try
            {
                this._trainigService.Edit(id, trainingDTO);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction("GetAll");
        }

        // DELETE api/<TrainingsController>/5
        [HttpDelete("{id}")]
        public ActionResult<TrainingDTO> Delete(int id)
        {
            this._trainigService.Delete(id);

            return this.RedirectToAction("GetAll");
        }
    }
}
