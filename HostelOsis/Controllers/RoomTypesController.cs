using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HostelOsis.Models.Data.HostelDBContext;
using HostelOsis.Models.Services;
using HostelOsis.Models.ViewModel;
using HostelOsis.Reports;

namespace HostelOsis.Controllers
{
    public class RoomTypesController : Controller
    {
        private RoomTypeService _roomTypeService;
       // private readonly RoomtypeReports _roomtypeReports;
        public RoomTypesController(RoomTypeService roomTypeService
           )
        {
            _roomTypeService = roomTypeService;
                
        }
        
        // GET: RoomType
        public ActionResult Index()
        {
            var model = _roomTypeService.GetRoomType();
            return View(model);
        }
      
        // GET: RoomType/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _roomTypeService.GetRoomTypeDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // GET: RoomType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomTypeViewModel model)
        {
            try
            {

                bool result = _roomTypeService.AddRoomType(model);

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

        // GET: RoomType/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _roomTypeService.GetRoomTypeDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: RoomType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RoomTypeViewModel model)
        {
            try
            {
                bool result = _roomTypeService.UpdateRoomType(model);

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

        // GET: RoomType/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _roomTypeService.GetRoomTypeDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: RoomType/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RoomTypeViewModel model)
        {
            try
            {
                bool result = _roomTypeService.RemoveRoomType(id);

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
