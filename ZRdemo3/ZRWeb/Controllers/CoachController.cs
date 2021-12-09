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
    public class CoachController : Controller
    {
        private readonly ICoachApi _coachApi;

        public CoachController()
        {
            this._coachApi = RestService.For<ICoachApi>("https://localhost:44301");
        }

        // GET: CoachController
        public async Task<ActionResult> Index()
        {
            var coaches = await this._coachApi.GetCoaches();

            return this.View(coaches);
        }

        // GET: CoachController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var coach = await this._coachApi.GetCoach(id);

            return this.View(coach);
        }

        // GET: CoachController/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: CoachController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CoachDTO coach)
        {
            try
            {
                await this._coachApi.Add(coach);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: CoachController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var coach = await this._coachApi.GetCoach(id);

            return this.View(coach);
        }

        // POST: CoachController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CoachDTO coach)
        {
            try
            {
                await this._coachApi.Edit(id, coach);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: CoachController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var coach = await this._coachApi.GetCoach(id);

            return this.View(coach);
        }

        // POST: CoachController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteCoach(int id)
        {
            try
            {
                await this._coachApi.Delete(id);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: CoachController/Schedule/5
        public async Task<ActionResult> Schedule(int id)
        {
            var coach = await this._coachApi.GetCoach(id);

            return this.View(coach);
        }

        // check ID
        public async Task<JsonResult> CheckID(int id)
        {
            var coach = await this._coachApi.GetCoach(id);

            var result = coach != null;

            return this.Json(result);
        }
    }
}
