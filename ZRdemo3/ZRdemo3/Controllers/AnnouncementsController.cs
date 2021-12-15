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
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementService _announcement;

        public AnnouncementsController(IAnnouncementService announcement)
        {
            this._announcement = announcement;
        }

        // GET: api/<AnnouncementsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnouncementDTO>>> GetAll()
        {
            var announcements = await this._announcement.GetAll();

            return this.Ok(announcements);
        }

        // GET api/<AnnouncementsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnnouncementDTO>> GetById(int id)
        {
            var announ = await this._announcement.GetOne(id);

            return this.Ok(announ);
        }

        // POST api/<AnnouncementsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AnnouncementDTO announcement)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                await this._announcement.Make(announcement);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.Ok();
        }

        // PUT api/<AnnouncementsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AnnouncementDTO announcement)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                await this._announcement.Edit(id, announcement);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.Ok();
        }

        // DELETE api/<AnnouncementsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await this._announcement.Delete(id);

            return this.Ok();
        }
    }
}
