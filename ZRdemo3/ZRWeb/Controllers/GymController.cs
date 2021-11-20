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
    public class GymController : Controller
    {
        private readonly IGymApi _gymApi;

        public GymController()
        {
            _gymApi = RestService.For<IGymApi>("https://localhost:44301");
        }
        // GET: GymController
        public async Task<ActionResult> Index()
        {
            var gyms = await this._gymApi.GetGyms();
            
            return View(gyms);
        }

        // GET: GymController/Details/5
        public async  Task<ActionResult> Details(int id)
        {
            var gym = await this._gymApi.GetById(id);
            return View(gym);
        }

        // GET: GymController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GymController/Create
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

        // GET: GymController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var gym = await this._gymApi.GetById(id);
            return View(gym);
        }

        // POST: GymController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GymDTO gymDTO)
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

        // GET: GymController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GymController/Delete/5
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
    }
}
