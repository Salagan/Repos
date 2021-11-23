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
    public class CoachesController : ControllerBase
    {
        private readonly ICoachService _coachService;

        public CoachesController(ICoachService coachService)
        {
            this._coachService = coachService;
        }

        // GET: api/<Coaches>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachDTO>>> GetAll()
        {
            var coaches = await this._coachService.GetCoaches();
            return this.Ok(coaches);
        }

        // GET api/<CoachesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoachDTO>> GetById(int? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }

            var coach = await this._coachService.GetCoach((int)id);

            return this.Ok(coach);
        }

        // POST api/<CoachesController>
        [HttpPost]
        public async Task<ActionResult<CoachDTO>> Add([FromBody] CoachDTO coachDTO)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                await this._coachService.Add(coachDTO);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction("GetAll");
        }

        // Update api/<CoachesController>/1
        [HttpPut("{id}")]
        public async Task<ActionResult<CoachDTO>> Update(int id, [FromBody]CoachDTO coachDTO)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (coachDTO.CoachId != id)
            {
                return this.BadRequest();
            }

            try
            {
                await this._coachService.Edit(id, coachDTO);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction("GetAll");
        }

        // DELETE api/<CoachesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CoachDTO>> Delete(int id)
        {
            await this._coachService.Delete(id);

            return this.Ok();
        }
    }
}
