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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CoachesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<CoachesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoachesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
