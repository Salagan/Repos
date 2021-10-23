using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZRdemoData.Models;
using ZRdemoData.Repositories;
using ZRdemoData.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ZRdemo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public StudentsController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<IEnumerable<StudentRepository>> GetAll()
        {
            var students = this._unitOfWork.Students.GetAll();
            return this.Ok(students);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<StudentRepository> GetById(int id)
        {
            var student = this._unitOfWork.Students.GetById(id);
            if (student == null)
            {
                return this.BadRequest();
            }

            return this.Ok(student);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<StudentRepository> Add([FromForm] Student student)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this._unitOfWork.Students.Add(student);
            this._unitOfWork.Complete();

            return this.RedirectToAction("GetAll");
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<StudentRepository> Update(int id, [FromForm] Student student)
        {
            if (id != student.StudentId)
            {
                return this.BadRequest();
            }

            try
            {
                this._unitOfWork.Students.Update(student);
                this._unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction("GetAll");
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult<StudentRepository> Delete(int id)
        {
            var student = this._unitOfWork.Students.GetById(id);

            if (student == null)
            {
                return this.BadRequest();
            }

            this._unitOfWork.Students.Remove(student);
            this._unitOfWork.Complete();

            return this.RedirectToAction("GetAll");
        }
    }
}
