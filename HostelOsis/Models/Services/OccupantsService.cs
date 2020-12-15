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
    public class OccupantsService
    {

        private HostelDBContext _context;
        private RoomService _roomService;
        public OccupantsService(HostelDBContext context, RoomService roomService)
        {
            _context = context;
            _roomService = roomService;
        }
        public List<OccupantViewModel> GetOccupants()
        {
            try
            {
                List<HostelOccupant> occupants = _context.HostelOccupant

                                         .Include(x => x.Room)
                                        
                                         .ToList();


                List<OccupantViewModel> viewModel = occupants.Select(x => new OccupantViewModel
                {
                    OccupantID = x.OccupantId,
                    Firstname = x.FirstName,
                    Surname=x.Surname,
                    DateOfBirth=x.DateOfBirth,
                    Gender=x.Gender,
                    MaritalStatus = x.MaritalStatus,
                    PhoneNumber=x.PhoneNumber,
                    RoomID = x.RoomId,
                    RoomNumber = x.Room.RoomNumber,
                    IsAvailable = x.Room.IsAvailable
                }).ToList();

                return viewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public OccupantViewModel GetOccupantsDetails(int id)
        {
            try
            {
                HostelOccupant occupant= _context.HostelOccupant
                                        .Where(x => x.OccupantId == id)
                                        .Include(x => x.Room)
                                        .FirstOrDefault();

                OccupantViewModel viewModel = new OccupantViewModel
                {
                    OccupantID = occupant.OccupantId,
                    Firstname = occupant.FirstName,
                    Surname = occupant.Surname,
                    DateOfBirth = occupant.DateOfBirth,
                    Gender = occupant.Gender,
                    MaritalStatus = occupant.MaritalStatus,
                    PhoneNumber = occupant.PhoneNumber,
                    RoomID = occupant.RoomId,
                    RoomNumber = occupant.Room.RoomNumber,
                    IsAvailable = occupant.Room.IsAvailable,
                    RoomList = new SelectList(_roomService.GetRooms(), "RoomID", "RoomNumber", occupant.RoomId)
                 };

                return viewModel;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public OccupantViewModel Create()
        {
            OccupantViewModel model = new OccupantViewModel();
            model.RoomList = new SelectList(_roomService.GetRooms(), "RoomID", "RoomNumber");
 
            return model;
        }

        public bool AddOccupannts(OccupantViewModel model)
        {
            try
            {
                HostelOccupant occupant = new HostelOccupant
                {

                   FirstName = model.Firstname,
                   Surname = model.Surname,
                   DateOfBirth = model.DateOfBirth,
                   Gender = model.Gender,
                   MaritalStatus = model.MaritalStatus,
                   PhoneNumber = model.PhoneNumber,
                   RoomId = model.RoomID
                };



                _context.HostelOccupant.Add(occupant);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool UpdateOccupant(OccupantViewModel model)
        {
            try
            {

                HostelOccupant occupant = new HostelOccupant();
               occupant= _context.HostelOccupant.Where(x => x.OccupantId == model.OccupantID).FirstOrDefault();
                occupant.FirstName = model.Firstname;
                occupant.Surname = model.Surname;
                occupant.DateOfBirth = model.DateOfBirth;
                occupant.Gender = model.Gender;
                occupant.MaritalStatus = model.MaritalStatus;
                occupant.PhoneNumber = model.PhoneNumber;
                occupant.RoomId = model.RoomID;

                _context.HostelOccupant.Update(occupant);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteOccupant(int id)
        {
            try
            {
                HostelOccupant occupant  = _context.HostelOccupant.Where(x => x.OccupantId == id).FirstOrDefault();

                _context.HostelOccupant.Remove(occupant);
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
