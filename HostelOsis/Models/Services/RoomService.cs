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
    public class RoomService
    {
        private HostelDBContext _context;       
        private FloorService _floorService;
        private RoomTypeService _roomTypeService;


        public RoomService(HostelDBContext context, FloorService floorService , RoomTypeService roomTypeService
         )
        {
            _context = context;
            _floorService = floorService;
            _roomTypeService = roomTypeService;
           
        }
        public List<RoomViewModel> GetRooms()
        {
            try
            {
                List<Room> rooms = _context.Room
                                         
                                         .Include(x => x.Floor)
                                         .Include(x => x.RoomType)  
                                         .ToList();


                List<RoomViewModel> viewModel = rooms.Select(x => new RoomViewModel
                {
                    RoomID = x.RoomId,
                   // Price = x.Price,
                    RoomNumber = x.RoomNumber,
                    IsAvailable =x.IsAvailable,
                    FloorID = x.FloorId,
                    RoomTypeID = x.RoomTypeId,
                    FloorName = x.Floor.FloorName,               
                    Type = x.RoomType.Type,
                    Capacity=x.RoomType.Capacity
                   
                }).ToList();

                return viewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public RoomViewModel GetRoomDetails(int id)
        {
            try
            {
                Room room = _context.Room
                                        .Where(x => x.RoomId == id)
                                        .Include(x => x.Floor)
                                                                         
                                        .Include(x => x.RoomType)
                                        .FirstOrDefault();

                RoomViewModel model = new RoomViewModel
                {
                    RoomID = room.RoomId,
                   // Price = room.Price,
                    RoomNumber = room.RoomNumber,
                    IsAvailable = room.IsAvailable,
                    FloorID = room.FloorId,
                                
                    RoomTypeID = room.RoomTypeId,
                
                    FloorName = room.Floor.FloorName,
                  
                    Type = room.RoomType.Type,
                  
                    
                    FloorList = new SelectList(_floorService.Getfloor(), "FloorID", "FloorName"),

                    RoomTypeList = new SelectList(_roomTypeService.GetRoomType(), "RoomTypeID", "Type")

                };

                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }



        public RoomViewModel Create()
        {
            RoomViewModel model = new RoomViewModel();
            model.FloorList = new SelectList(_floorService.Getfloor(), "FloorID", "FloorName");
            model.RoomTypeList = new SelectList(_roomTypeService.GetRoomType(), "RoomTypeID", "Type");
            

            return model;
        }
        public bool AddRoom(RoomViewModel model)
        {
            try
            {
                Room room = new Room
               {

                 //Price = model.Price,
                 RoomNumber = model.RoomNumber,
                 IsAvailable = model.IsAvailable,
                 FloorId = model.FloorID,
                 // room.HostelId = (int)model.HostelID;
                 RoomTypeId = model.RoomTypeID
               };

                   

                _context.Room.Add(room);
                _context.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool UpdateRoom(RoomViewModel model)
        {
            try
            {
                Room room = new Room();
                room = _context.Room.Where(x => x.RoomId == model.RoomID).FirstOrDefault();

                //room.Price = model.Price;
                room.RoomNumber = model.RoomNumber;
                room.IsAvailable = model.IsAvailable;               
                room.FloorId = model.FloorID;
               // room.HostelId = (int)model.HostelID;
                room.RoomTypeId = model.RoomTypeID;
                

                _context.Room.Update(room);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteRoom(int id)
        {
            try
            {
                Room room = _context.Room.Where(x => x.RoomId == id).FirstOrDefault();

                _context.Room.Remove(room);
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
