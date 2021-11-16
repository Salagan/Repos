﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZRdemoBll.Interfaces;
using ZRdemoBll.ModelsDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ZRdemo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupOfStudentsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupOfStudentsController(IGroupService groupService)
        {
            this._groupService = groupService;
        }

        // GET: api/<GroupOfStudentsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupOfStudentsDTO>>> GetAll()
        {
            var groups = await this._groupService.GetGroups();

            return this.Ok(groups);
        }

        // GET api/<GroupOfStudentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupOfStudentsDTO>> GetById(int id)
        {
            var group = await this._groupService.GetGroup(id);

            return this.Ok(group);
        }

        // POST api/<GroupOfStudentsController>
        [HttpPost]
        public ActionResult<GroupOfStudentsDTO> Add([FromBody] GroupOfStudentsDTO group)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._groupService.Add(group);

            return this.RedirectToAction("GetAll");
        }

        // PUT api/<GroupOfStudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<GroupOfStudentsDTO> Update(int id, [FromBody] GroupOfStudentsDTO group)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != group.Id)
            {
                return this.BadRequest();
            }

            this._groupService.Edit(id, group);

            return this.RedirectToAction("GetAll");
        }

        // DELETE api/<GroupOfStudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult<GroupOfStudentsDTO> Delete(int id)
        {
            this._groupService.Delete(id);

            return this.RedirectToAction("GetAll");
        }
    }
}
