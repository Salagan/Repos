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
    public class GuestCoachesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GuestCoachesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/<Controller>
        [HttpGet]
        public ActionResult<IEnumerable<GuestCoachRepository>> GetAll()
        {
            var guestCoaches = this._unitOfWork.Guests.GetAll();
            return this.Ok(guestCoaches);
        }

        // GET api/<Controllerr>/5
        [HttpGet("{id}")]
        public ActionResult<GuestCoachRepository> GetById(int id)
        {
            var guestCoach = this._unitOfWork.GuestCoaches.GetById(id);
            if (guestCoach == null)
            {
                return this.BadRequest();
            }

            return this.Ok(guestCoach);
        }

        // POST api/<Controller>
        [HttpPost]
        public ActionResult<GuestCoachRepository> Add([FromBody] GuestCoach guestCoach)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._unitOfWork.GuestCoaches.Add(guestCoach);
            this._unitOfWork.Complete();

            return this.RedirectToAction("GetAll");
        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public ActionResult<GuestCoachRepository> Update(int id, [FromForm] GuestCoach guestCoach)
        {
            if (id != guestCoach.Id)
            {
                return this.BadRequest();
            }

            try
            {
                this._unitOfWork.GuestCoaches.Update(guestCoach);
                this._unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction("GetAll");
        }

        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public ActionResult<GuestCoachRepository> Delete(int id)
        {
            var guestCoach = this._unitOfWork.GuestCoaches.GetById(id);

            if (guestCoach == null)
            {
                return this.BadRequest();
            }

            this._unitOfWork.GuestCoaches.Remove(guestCoach);
            this._unitOfWork.Complete();

            return this.RedirectToAction("GetAll");
        }
    }
}
