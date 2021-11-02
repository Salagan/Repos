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
    public class GuestsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GuestsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/<Controller>
        [HttpGet]
        public ActionResult<IEnumerable<GuestRepository>> GetAll()
        {
            var guests = this._unitOfWork.Guests.GetAll();
            return this.Ok(guests);
        }

        // GET api/<Controllerr>/5
        [HttpGet("{id}")]
        public ActionResult<GuestRepository> GetById(int id)
        {
            var guest = this._unitOfWork.Guests.GetById(id);
            if (guest == null)
            {
                return this.BadRequest();
            }

            return this.Ok(guest);
        }

        // POST api/<Controller>
        [HttpPost]
        public ActionResult<GuestRepository> Add([FromBody] Guest guest)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._unitOfWork.Guests.Add(guest);
            this._unitOfWork.Complete();

            return this.RedirectToAction("GetAll");
        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public ActionResult<GuestRepository> Update(int id, [FromForm] Guest guest)
        {
            if (id != guest.Id)
            {
                return this.BadRequest();
            }

            try
            {
                this._unitOfWork.Guests.Update(guest);
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
        public ActionResult<GuestRepository> Delete(int id)
        {
            var guest = this._unitOfWork.Guests.GetById(id);

            if (guest == null)
            {
                return this.BadRequest();
            }

            this._unitOfWork.Guests.Remove(guest);
            this._unitOfWork.Complete();

            return this.RedirectToAction("GetAll");
        }
    }
}
