using HostelOsis.Models.Data.HostelDBContext;
using HostelOsis.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostelOsis.Models.Services
{
    public class BookingService
    {
        private HostelDBContext _context;
        private RoomService _roomService;
        public BookingService(HostelDBContext context, RoomService roomService)
        {
            _context = context;
            _roomService = roomService;
        }
        public List<BookingViewModel> Getbookings()
        {
            try
            {
                List<BookingDetails> bookingDetails = _context.BookingDetails
                                         .Include(x => x.Room).ToList();


                List<BookingViewModel> viewModel = bookingDetails.Select(x => new BookingViewModel
                {
                    BillID =x.BillId,
                    ArrivalDate = x.ArrivalDate,
                    DepartureDate = x.DepartureDate,
                    
                    RoomID = x.RoomId,
                    Price = x.Price,
                    RoomNumber = x.Room.RoomNumber,
                    IsAvailable =x.Room.IsAvailable,

                }).ToList();

                return viewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public BookingViewModel GetBookingDetails(int id)
        {
            try
            {
                BookingDetails booking = _context.BookingDetails
                                        .Where(x => x.BillId == id)
                                       .Include(x => x.Room)
                                        .FirstOrDefault();

                BookingViewModel model = new BookingViewModel
                {
                    BillID = booking.BillId,
                    ArrivalDate = booking.ArrivalDate,
                    DepartureDate = booking.DepartureDate,
                    RoomID = booking.RoomId,
                    Price = booking.Price,
                    RoomNumber = booking.Room.RoomNumber,
                    IsAvailable = booking.Room.IsAvailable,

                    RoomList = new SelectList(_roomService.GetRooms(), "RoomID", "RoomNumber", booking.RoomId)
                    //NumberList = new SelectList(_roomService.GetRooms(), "RoomID", "RoomNumber", booking.Room.RoomNumber),
                    //AvailableList = new SelectList(_roomService.GetRooms(), "RoomID", "IsAvailable", booking.Room.RoomNumber)
                    

                };

                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public BookingViewModel Create()
        {
            BookingViewModel model = new BookingViewModel();
            model.RoomList = new SelectList(_roomService.GetRooms(), "RoomID", "RoomNumber");
           // model.NumberList = new SelectList(_roomService.GetRooms(), "RoomId", "RoomNumber");
           // model.AvailableList = new SelectList(_roomService.GetRooms(), "RoomId", "IsAvailable");
            return model;
        }
        

        public bool AddBooking(BookingViewModel model)
        {
            try
            {
                BookingDetails booking = new BookingDetails
                {
                    ArrivalDate =model.ArrivalDate,
                    DepartureDate=model.DepartureDate,
                    RoomId = model.RoomID,
                    Price=model.Price
                };

                _context.BookingDetails.Add(booking);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Updatebooking(BookingViewModel model)
        {
            try
            {
                BookingDetails booking = _context.BookingDetails.Where(x => x.BillId ==model.BillID).FirstOrDefault();

                booking.ArrivalDate = model.ArrivalDate;
                booking.DepartureDate = model.DepartureDate;
                booking.RoomId = model.RoomID;
                booking.Price = model.Price;

                _context.BookingDetails.Update(booking);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteBooking(int id)
        {
            try
            {
                BookingDetails booking = _context.BookingDetails.Where(x => x.BillId == id).FirstOrDefault();

                _context.BookingDetails.Remove(booking);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
