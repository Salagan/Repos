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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAll()
        {
            var students = await this._studentService.GetStudents();
            return this.Ok(students);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetById(int id)
        {
            var student = await this._studentService.GetStudent(id);
            return this.Ok(student);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> Add([FromBody] StudentDTO studentDTO)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                await this._studentService.Add(studentDTO);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction("GetAll");
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDTO>> Update(int id, [FromBody] StudentDTO studentDTO)
        {
            if (id != studentDTO.StudentId)
            {
                return this.BadRequest();
            }

            try
            {
                await this._studentService.Edit(id, studentDTO);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.GetAll));
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDTO>> Delete(int id)
        {
            await this._studentService.Delete(id);

            return this.RedirectToAction("GetAll");
        }
    }
}
