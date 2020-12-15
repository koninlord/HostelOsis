using HostelOsis.Models.Data.HostelDBContext;
using HostelOsis.Models.ViewModel;
using HostelOsis.Reports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostelOsis.Models.Services
{
    public class RoomTypeService
    {
        private HostelDBContext _context;

        public RoomTypeService(HostelDBContext context)
        {
            _context = context;
        }
        
        public bool AddRoomType(RoomTypeViewModel model)
        { 
            try
            {
                RoomType roomtype = new RoomType();
                roomtype.Type = model.Type;
                roomtype.Capacity = model.Capacity;

                _context.RoomType.Add(roomtype);
                _context.SaveChanges();

                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
        public List<RoomTypeViewModel> GetRoomType()
        {
            try
            {
                var roomtype = _context.RoomType.ToList();

                List<RoomTypeViewModel> model = roomtype.Select(x => new RoomTypeViewModel
                {
                    RoomTypeID = x.RoomTypeId,
                    Type = x.Type,
                    Capacity = x.Capacity
                }).ToList();

                
                return model;
            }
            catch (Exception)
            {
                List<RoomTypeViewModel> emptyModel = new List<RoomTypeViewModel>();
                return emptyModel;
            }
        }

        public RoomTypeViewModel GetRoomTypeDetails(int id)
        {
            try
            {
                RoomType roomtype  = _context.RoomType.Where(x => x.RoomTypeId == id).First();

                RoomTypeViewModel model = new RoomTypeViewModel
                {
                    RoomTypeID = roomtype.RoomTypeId,
                    Type = roomtype.Type,
                    Capacity = roomtype.Capacity
                };

                return model;
            }
            catch (Exception)
            {
                RoomTypeViewModel emptyModel = new RoomTypeViewModel();
                return emptyModel;
            }
        }

        public bool UpdateRoomType(RoomTypeViewModel model)
        {
            try
            {
                RoomType roomtype = _context.RoomType.Where(x => x.RoomTypeId == model.RoomTypeID).First();
                roomtype.Type = model.Type;

                _context.RoomType.Update(roomtype);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveRoomType(int id)
        {
            try
            {
                RoomType roomtype = _context.RoomType.Where(x => x.RoomTypeId == id).First();

                _context.RoomType.Remove(roomtype);
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
