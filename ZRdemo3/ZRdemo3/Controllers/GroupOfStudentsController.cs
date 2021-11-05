﻿using System;
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
    public class GroupOfStudentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupOfStudentsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/<GroupOfStudentsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupOfStudentsRepository>>> GetAll()
        {
            var groups = await this._unitOfWork.GroupsOfStudents.GetAll();
            return this.Ok(groups);
        }

        // GET api/<GroupOfStudentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupOfStudentsRepository>> GetById(int id)
        {
            var group = await this._unitOfWork.GroupsOfStudents.GetById(id);
            if (group == null)
            {
                return this.BadRequest();
            }

            return this.Ok(group);
        }

        // POST api/<GroupOfStudentsController>
        [HttpPost]
        public async Task<ActionResult<GroupOfStudentsRepository>> Add([FromBody] GroupOfStudents group)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._unitOfWork.GroupsOfStudents.Add(group);
            await this._unitOfWork.Complete();

            return this.RedirectToAction("GetAll");
        }

        // PUT api/<GroupOfStudentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GroupOfStudentsRepository>> Update(int id, [FromForm] GroupOfStudents group)
        {
            if (id != group.Id)
            {
                return this.BadRequest();
            }

            try
            {
                this._unitOfWork.GroupsOfStudents.Update(group);
                await this._unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction("GetAll");
        }

        // DELETE api/<GroupOfStudentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupOfStudentsRepository>> Delete(int id)
        {
            var group = await this._unitOfWork.GroupsOfStudents.GetById(id);

            if (group == null)
            {
                return this.BadRequest();
            }

            this._unitOfWork.GroupsOfStudents.Remove(group);
            await this._unitOfWork.Complete();

            return this.RedirectToAction("GetAll");
        }
    }
}
