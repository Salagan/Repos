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
    public class GuestController : Controller
    {
        private readonly IGuestApi _guestApi;

        public GuestController()
        {
            this._guestApi = RestService.For<IGuestApi>("https://localhost:44301");
        }

        // GET: GuestController
        public async Task<ActionResult> Index()
        {
            var guests = await this._guestApi.GetGuests();

            return this.View(guests);
        }

        // GET: GuestController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var guest = await this._guestApi.GetGuest(id);

            return this.View(guest);
        }

        // GET: GuestController/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: GuestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GuestDTO guest)
        {
            try
            {
                await this._guestApi.Add(guest);
            }
            catch (Exception ex)
            {
                return this.View(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: GuestController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var guest = await this._guestApi.GetGuest(id);

            return this.View(guest);
        }

        // POST: GuestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, GuestDTO guest)
        {
            try
            {
                await this._guestApi.Edit(id, guest);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: GuestController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var guest = await this._guestApi.GetGuest(id);

            return this.View(guest);
        }

        // POST: GuestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteGuest(int id)
        {
            try
            {
                await this._guestApi.Delete(id);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
