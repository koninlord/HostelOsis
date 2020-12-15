using HostelOsis.Models.Data.HostelDBContext;
using HostelOsis.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostelOsis.Models.Services
{
    public class FloorService
    {
        private HostelDBContext _context;

        public FloorService(HostelDBContext context)
        {
            _context = context;
        }
        public bool AddFloor(FloorViewModel model)
        {
            try
            {
                Floor floor = new Floor();
                floor.FloorName = model.FloorName;
               
                _context.Floor.Add(floor);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<FloorViewModel> Getfloor()
        {
            try
            {
                var floor = _context.Floor.ToList();

                List<FloorViewModel> model = floor.Select(x => new FloorViewModel
                {
                    FloorID = x.FloorId,
                    FloorName = x.FloorName
                     
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                List<FloorViewModel> emptyModel = new List<FloorViewModel>();
                return emptyModel;
            }
        }
        public FloorViewModel GetFloorDetails(int id)
        {
            try
            {
                Floor floor = _context.Floor.Where(x => x.FloorId == id).First();

                FloorViewModel model = new FloorViewModel
                {
                    FloorID =floor.FloorId,
                    FloorName = floor.FloorName
                    
                };

                return model;
            }
            catch (Exception)
            {
                FloorViewModel emptyModel = new FloorViewModel();
                return emptyModel;
            }
        }
        public bool UpdateFloor(FloorViewModel model)
        {
            try
            {
                Floor floor = _context.Floor.Where(x => x.FloorId == model.FloorID).First();
                floor.FloorName = model.FloorName;

                _context.Floor.Update(floor);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveFloor(int id)
        {
            try
            {
                Floor floor = _context.Floor.Where(x => x.FloorId == id).FirstOrDefault();

                _context.Floor.Remove(floor);
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
