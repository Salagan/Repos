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
    public class TrainingsController : Controller
    {
        private readonly ITrainingsApi _trainingsApi;

        public TrainingsController()
        {
            this._trainingsApi = RestService.For<ITrainingsApi>("https://localhost:44301");
        }

        // GET: TrainingsController
        public async Task<ActionResult> Schedule()
        {
            var trainings = await this._trainingsApi.GetTrainings();

            return this.View(trainings);
        }

        // GET: TrainingsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var training = await this._trainingsApi.GetTraining(id);

            return this.View(training);
        }

        // GET: TrainingsController/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: TrainingsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TrainingDTO training)
        {
            try
            {
                await this._trainingsApi.Add(training);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Schedule));
        }

        // GET: TrainingsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var training = await this._trainingsApi.GetTraining(id);

            return this.View(training);
        }

        // POST: TrainingsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TrainingDTO training)
        {
            try
            {
                await this._trainingsApi.Edit(id, training);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Schedule));
        }

        // GET: TrainingsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var training = await this._trainingsApi.GetTraining(id);

            return this.View(training);
        }

        // POST: TrainingsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteTraining(int id)
        {
            try
            {
                await this._trainingsApi.Delete(id);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.RedirectToAction(nameof(this.Schedule));
        }
    }
}
