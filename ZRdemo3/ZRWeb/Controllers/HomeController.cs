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
    public class HomeController : Controller
    {
        private readonly IAnnouncementApi _ad;

        public HomeController()
        {
            this._ad = RestService.For<IAnnouncementApi>("https://localhost:44301");
        }

        // GET: HomeController
        public async Task<ActionResult<IEnumerable<AnnouncementDTO>>> Index()
        {
            var ads = await this._ad.GetAll();

            return this.View(ads);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AnnouncementDTO announcement)
        {
            try
            {
                await this._ad.Add(announcement);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: HomeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var announ = await this._ad.GetAd(id);

            return this.View(announ);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AnnouncementDTO announcement)
        {
            try
            {
                await this._ad.Edit(id, announcement);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: HomeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var announ = await this._ad.GetAd(id);

            return this.View(announ);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAnnouncement(int id)
        {
            try
            {
                await this._ad.Delete(id);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
