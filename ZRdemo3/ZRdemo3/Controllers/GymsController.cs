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
    public class GymsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GymsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/<GymsController>
        [HttpGet]
        public ActionResult<IEnumerable<GymRepository>> GetAll()
        {
            var gyms = this._unitOfWork.Gyms.GetAll();
            return this.Ok(gyms);
        }

        // GET api/<GymsControllerr>/5
        [HttpGet("{id}")]
        public ActionResult<GymRepository> GetById(int id)
        {
            var gym = this._unitOfWork.Gyms.GetById(id);
            if (gym == null)
            {
                return this.BadRequest();
            }

            return this.Ok(gym);
        }

        // POST api/<GymsController>
        [HttpPost]
        public ActionResult<GymRepository> Add([FromBody] Gym gym)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._unitOfWork.Gyms.Add(gym);
            this._unitOfWork.Complete();

            return this.RedirectToAction("GetAll");
        }

        // PUT api/<GymsController>/5
        [HttpPut("{id}")]
        public ActionResult<GymRepository> Update(int id, [FromBody] Gym gym)
        {
            if (id != gym.Id)
            {
                return this.BadRequest();
            }

            try
            {
                this._unitOfWork.Gyms.Update(gym);
                this._unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.Ok(gym);
        }

        // DELETE api/<GymsController>/5
        [HttpDelete("{id}")]
        public ActionResult<GymRepository> Delete(int id)
        {
            var gym = this._unitOfWork.Gyms.GetById(id);

            if (gym == null)
            {
                return this.BadRequest();
            }

            this._unitOfWork.Gyms.Remove(gym);
            this._unitOfWork.Complete();

            return this.RedirectToAction("GetAll");
        }
    }
}
