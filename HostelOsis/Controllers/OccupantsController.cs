using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HostelOsis.Models.Services;
using HostelOsis.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostelOsis.Controllers
{
    public class OccupantsController : Controller
    {
        private OccupantsService _occupantsService;
        public OccupantsController(OccupantsService occupantsService)
        {
            _occupantsService = occupantsService;
        }
        // GET: Occupants
        public ActionResult Index()
        {
            var model = _occupantsService.GetOccupants();
            return View(model);
        }

        // GET: Occupants/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _occupantsService.GetOccupantsDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Occupants/Create
        public ActionResult Create()
        {
            var model = _occupantsService.Create();
            return View(model);
        }

        // POST: Occupants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OccupantViewModel model)
        {
            try
            {

                bool result = _occupantsService.AddOccupannts(model);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();

            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ooops! Something went wrong!");
                return View();
            }
        }

        // GET: Occupants/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _occupantsService.GetOccupantsDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Occupants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OccupantViewModel model)
        {
            try
            {
                bool result = _occupantsService.UpdateOccupant(model);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ooops! Something went wrong!");
                return View();
            }
        }

        // GET: Occupants/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _occupantsService.GetOccupantsDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Occupants/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bool result = _occupantsService.DeleteOccupant(id);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ooops! Something went wrong!");
                return View();
            }
        }
    }
}