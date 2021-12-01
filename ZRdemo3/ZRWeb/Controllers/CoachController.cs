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
    public class CoachController : Controller
    {
        private readonly ICoachApi _coachApi;

        public CoachController()
        {
            _coachApi = RestService.For<ICoachApi>("https://localhost:44301");
        }
        // GET: CoachController
        public async Task<ActionResult> Index()
        {
            var coaches = await this._coachApi.GetCoaches();

            return View(coaches);
        }

        // GET: CoachController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var coach = await this._coachApi.GetCoach(id);

            return View(coach);
        }

        // GET: CoachController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoachController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoachController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CoachController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoachController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CoachController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET: CoachController/Schedule/5
        public async Task<ActionResult> Schedule(int id)
        {
            var coach = await this._coachApi.GetCoach(id);

            return View(coach);
        }
    }
}
