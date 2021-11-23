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
        public async Task<ActionResult> Create(GymDTO gymDTO)
        {
            try
            {
                await this._gymApi.Create(gymDTO);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
            return RedirectToAction("Index");
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
        public async  Task<ActionResult> Edit(GymDTO gymDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this._gymApi.Edit(gymDTO.Id, gymDTO);
                }
                catch(Exception ex)
                {
                    return this.BadRequest(ex.Message);
                }
                return RedirectToAction("Index");
            }
            return View(gymDTO);
        }

        // GET: GymController/Delete/5
        public ActionResult Delete(int id)
        {
            var gym = this._gymApi.GetById(id);

            return View(gym);
        }

        // Delete: GymController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteGym(int id)
        {
            try
            {
                await this._gymApi.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}
