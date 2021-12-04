using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using ZRdemoContracts.ModelsDTO;
using ZRWeb.HttpClients;

namespace ZRWeb.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupsApi _groupOfStudent;

        public GroupsController()
        {
            this._groupOfStudent = RestService.For<IGroupsApi>("https://localhost:44301");
        }

        // GET: GroupsController
        public async Task<ActionResult> Index()
        {
            var groups = await this._groupOfStudent.GetGroups();

            return this.View(groups);
        }

        // GET: GroupsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var group = await this._groupOfStudent.GetGroup(id);

            return this.View(group);
        }

        public async Task<ActionResult> Schedule(int id)
        {
            var group = await this._groupOfStudent.GetGroup(id);

            return this.View(group);
        }

        // GET: GroupsController/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: GroupsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GroupOfStudentsDTO group)
        {
            try
            {
                await this._groupOfStudent.Add(group);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: GroupOfStudentsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var group = await this._groupOfStudent.GetGroup(id);

            return this.View(group);
        }

        // POST: GroupOfStudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, GroupOfStudentsDTO group)
        {
            try
            {
                await this._groupOfStudent.Edit(id, group);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: GroupOfStudentsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var group = await this._groupOfStudent.GetGroup(id);

            return this.View(group);
        }

        // POST: GroupOfStudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            try
            {
                await this._groupOfStudent.Delete(id);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
