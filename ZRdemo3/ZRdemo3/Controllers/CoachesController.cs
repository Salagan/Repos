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
    public class CoachesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoachesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

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
        public ActionResult<CoachRepository> Add([FromBody] Coach coach)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._unitOfWork.Coaches.Add(coach);
            return this.Ok(coach);
        }

        // PUT api/<CoachesController>/5
        [HttpPut("{id}")]
        public ActionResult<CoachRepository> Update(int id, [FromBody] Coach coachM)
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
                coach = coachM;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return this.BadRequest();
            }

            this._unitOfWork.Coaches.Update(coach);

            return this.Ok(coach);
        }

        // DELETE api/<CoachesController>/5
        [HttpDelete("{id}")]
        public ActionResult<CoachRepository> Delete(int id)
        {
            var coach = this._unitOfWork.Coaches.GetById(id);
            this._unitOfWork.Coaches.Remove(coach);
            return this.Ok();
        }
    }
}
