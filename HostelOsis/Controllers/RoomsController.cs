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
    public class RoomsController : Controller
    {
        private RoomService _roomService;
        public RoomsController(RoomService roomService)
        {
            _roomService = roomService;
        }
        // GET: Rooms
        public ActionResult Index()
        {
            var model = _roomService.GetRooms();
            return View(model);
        }

        // GET: Rooms/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _roomService.GetRoomDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
            
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            var model = _roomService.Create();
            return View(model);
        }

        // POST: Rooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomViewModel model)
        {
            try
            {

                bool result = _roomService.AddRoom(model);

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

        // GET: Rooms/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _roomService.GetRoomDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RoomViewModel model)
        {
            try
            {
                bool result = _roomService.UpdateRoom(model);

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

        // GET: Rooms/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _roomService.GetRoomDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Rooms/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RoomViewModel model)
        {
            try
            {
                bool result = _roomService.DeleteRoom(id);

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