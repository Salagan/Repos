using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        private IMapper Mapper { get; set; }

        // GET: api/<Coaches>
        [HttpGet]
        public ActionResult<IEnumerable<CoachRepository>> GetAll()
        {
            var coaches = this._unitOfWork.Coaches.GetAll();
            return this.Ok(coaches);
        }

        // GET api/<CoachesController>/5
        [HttpGet("{id}")]
        public ActionResult<CoachRepository> GetById(int id)
        {
            var coach = this._unitOfWork.Coaches.GetById(id);
            return this.Ok(coach);
        }

        // POST api/<CoachesController>
        [HttpPost]
        public ActionResult<CoachRepository> Add([FromForm] Coach coach)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._unitOfWork.Coaches.Add(coach);
            this._unitOfWork.Complete();
            return this.Ok(coach);
        }

        // PUT api/<CoachesController>/5
        [HttpPut("{id}")]
        public ActionResult<CoachRepository> Update(int id, [FromForm] Coach model)
        {
            var coach = this._unitOfWork.Coaches.GetById(id);
            if (!this.ModelState.IsValid)
            {
               return this.BadRequest(this.ModelState);
            }

            if (coach == null)
            {
               return this.BadRequest();
            }

            try
            {
                this.Mapper.Map(model, coach);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            this._unitOfWork.Coaches.Update(coach);
            this._unitOfWork.Complete();

            return this.Ok(coach);
        }

        // DELETE api/<CoachesController>/5
        [HttpDelete("{id}")]
        public ActionResult<CoachRepository> Delete(int id)
        {
            var coach = this._unitOfWork.Coaches.GetById(id);
            this._unitOfWork.Coaches.Remove(coach);
            this._unitOfWork.Complete();
            return this.Ok();
        }
    }
}
