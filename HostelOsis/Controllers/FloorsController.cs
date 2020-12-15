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
    public class FloorsController : Controller
    {
        private FloorService _floorService;
        public FloorsController(FloorService floorService)
        {
            _floorService = floorService;
        }
        // GET: Floors
        public ActionResult Index()
        {
            var model = _floorService.Getfloor();
            return View(model);
        }

        // GET: Floors/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _floorService.GetFloorDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Floors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Floors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FloorViewModel model)
        {
            try
            {

                bool result = _floorService.AddFloor(model);

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

        // GET: Floors/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _floorService.GetFloorDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Floors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FloorViewModel model)
        {
            try
            {
                bool result = _floorService.UpdateFloor(model);

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

        // GET: Floors/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _floorService.GetFloorDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Floors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FloorViewModel model)
        {
            try
            {
                bool result = _floorService.RemoveFloor(id);

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