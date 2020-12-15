using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HostelOsis.Models.Data.HostelDBContext;
using HostelOsis.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace HostelOsis.Controllers
{
    public class ReportController : Controller
    {
        private RoomType _roomType;

        public ReportController(RoomType roomType)
        {
            _roomType = roomType;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult PrintRoomtype(int param)
        {
            List<RoomType> roomTypes = new List<RoomType>();

            for (int i = 1; i <= 10; i++)
            {
                RoomType roomType = new RoomType();
                roomType.RoomTypeId = i;
                roomType.Type = "Type" + i;
                //  roomType.Capacity = "Capacity" + i;
                roomTypes.Add(roomType);
            }
            RoomtypeReportService rpt = new RoomtypeReportService();
            return File(rpt.Reports(roomTypes), "application/pdf");
        }
    }
}