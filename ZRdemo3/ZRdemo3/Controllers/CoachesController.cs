using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZRdemoBll.ModelsDTO;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;
using ZRdemoData.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ZRdemo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoachesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/<Coaches>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachRepository>>> GetAll()
        {
            var coaches = await this._unitOfWork.Coaches.GetAll();
            return this.Ok(coaches);
        }

        // GET api/<CoachesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoachRepository>> GetById(int id)
        {
            var coach = await this._unitOfWork.Coaches.GetById(id);
            return this.Ok(coach);
        }

        // POST api/<CoachesController>
        [HttpPost]
        public async Task<ActionResult<CoachRepository>> Add([FromBody] Coach coach)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._unitOfWork.Coaches.Add(coach);
            await this._unitOfWork.Complete();
            return this.Ok(coach);
        }

        // Update api/<CoachesController>/1
        // patch
        [HttpPut("{id}")]
        public async Task<ActionResult<CoachRepository>> Update(int id, [FromForm]Coach coach)
        {
            if (coach.CoachId != id)
            {
                return this.BadRequest();
            }

            try
            {
                this._unitOfWork.Coaches.Update(coach);
                await this._unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction("GetAll");
        }

        // DELETE api/<CoachesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CoachRepository>> Delete(int id)
        {
            var coach = await this._unitOfWork.Coaches.GetById(id);
            this._unitOfWork.Coaches.Remove(coach);
            await this._unitOfWork.Complete();
            return this.Ok();
        }
    }
}
