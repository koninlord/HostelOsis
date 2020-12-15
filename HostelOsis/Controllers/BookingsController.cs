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
    
    public class BookingsController : Controller
    {
        private BookingService _bookingService;
        public BookingsController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }
        // GET: Bookings
        public ActionResult Index()
        {
            var model = _bookingService.Getbookings();
            return View(model);
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = _bookingService.GetBookingDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            var model = _bookingService.Create();
            return View(model);
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingViewModel model)
        {
            try
            {

                bool result = _bookingService.AddBooking(model);

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

        // GET: Bookings/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var model = _bookingService.GetBookingDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookingViewModel model)
        {
            try
            {
                bool result = _bookingService.Updatebooking(model);

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

        // GET: Bookings/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _bookingService.GetBookingDetails(id);
                return View(model);
            }
            catch
            {

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Bookings/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BookingViewModel model)
        {
            try
            {
                bool result = _bookingService.DeleteBooking(id);

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