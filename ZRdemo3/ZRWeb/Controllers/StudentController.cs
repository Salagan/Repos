using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZRdemoContracts.ModelsDTO;
using ZRWeb.HttpClients;

namespace ZRWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentApi _studentApi;

        public StudentController()
        {
            _studentApi = RestService.For<IStudentApi>("https://localhost:44301");
        }

        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            var students = await this._studentApi.GetStudents();

            return View(students);
        }

        // GET: StudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var student = await this._studentApi.GetStudent(id);

            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentDTO studentDTO)
        {
            try
            {
                await this._studentApi.AddStudent(studentDTO);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var student = await this._studentApi.GetStudent(id);

            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this._studentApi.Edit(id, student);
                }
                catch (Exception ex)
                {
                    return this.BadRequest(ex.Message);
                }
                return RedirectToAction(nameof(this.Index));
            }
            return View(student);
        }

        // GET: StudentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var student = await this._studentApi.GetStudent(id);

            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                await this._studentApi.Delete(id);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
            return RedirectToAction(nameof(this.Index));
        }
    }
}
