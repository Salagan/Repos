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
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestsController(IGuestService guestService)
        {
            this._guestService = guestService;
        }

        // GET: api/<Controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestDTO>>> GetAll()
        {
            var guests = await this._guestService.GetGuests();

            return this.Ok(guests);
        }

        // GET api/<Controllerr>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDTO>> GetById(int id)
        {
            var guest = await this._guestService.GetGuest(id);

            return this.Ok(guest);
        }

        // POST api/<Controller>
        [HttpPost]
        public async Task<ActionResult<GuestDTO>> Add([FromBody] GuestDTO guestDTO)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
               await this._guestService.Add(guestDTO);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.Ok();
        }

        // PUT api/<Controller>/5
        [HttpPost("{id}")]
        public async Task<ActionResult<GuestDTO>> Update(int id, [FromBody] GuestDTO guestDTO)
        {
            if (id != guestDTO.Id)
            {
                return this.BadRequest();
            }

            try
            {
               await this._guestService.Edit(id, guestDTO);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.Ok();
        }

        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GuestDTO>> Delete(int id)
        {
            await this._guestService.Delete(id);

            return this.Ok();
        }
    }
}
