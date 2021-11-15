using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZRdemoBll.Interfaces;
using ZRdemoBll.ModelsDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ZRdemo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymsController : ControllerBase
    {
        private readonly IGymService _gymService;

        public GymsController(IGymService serv)
        {
            this._gymService = serv;
        }

        // GET: api/<GymsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymDTO>>> GetAll()
        {
            var gymDTOs = await this._gymService.GetGyms();
            return this.Ok(gymDTOs);
        }

        // GET api/<GymsControllerr>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GymDTO>> GetById(int id)
        {
            var gymDTO = await this._gymService.GetGymById(id);
            if (gymDTO == null)
            {
                return this.BadRequest();
            }

            return this.Ok(gymDTO);
        }

        // POST api/<GymsController>
        [HttpPost]
        public ActionResult<GymDTO> Add([FromBody] GymDTO gymDTO)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._gymService.Add(gymDTO);
            return this.RedirectToAction("GetAll");
        }

        // PUT api/<GymsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GymDTO>> Update(int id, [FromBody] GymDTO gymDTO)
        {
            var gym = await this._gymService.Edit(id, gymDTO);

            return this.Ok(gym);
        }

        // DELETE api/<GymsController>/5
        [HttpDelete("{id}")]
        public ActionResult<GymDTO> Delete(int id)
        {
            this._gymService.Delete(id);

            return this.RedirectToAction("GetAll");
        }
    }
}
