using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HostelOsis.Models.ViewModel
{
    public class RoomViewModel
    {
        public int RoomID { get; set; }
        //public decimal Price { get; set; }
        [Display(Name = "Room Number")]
        [Required(ErrorMessage = "Select Room number please")]
        public int RoomNumber { get; set; }
        [Display(Name = "Available")]
        [Required(ErrorMessage = "Please indicate room availabilty")]
        public string IsAvailable { get; set; }

        [Display(Name = "Floor")]
        [Required(ErrorMessage = "Select Floor")]
        public int FloorID { get; set; }
        [Display(Name = "Type")]
        public string FloorName { get; set; }
        [Display(Name = "Room Type")]
        [Required(ErrorMessage = "Select Room type")]
        public int RoomTypeID { get; set; }
        [Display(Name = "Floor Name")]
        public string Type { get; set; }
        public int Capacity { get; set; }
       
        public SelectList FloorList { get; set; }
        //public SelectList HostelList { get; set; }
        public SelectList RoomTypeList { get; set; }


    }
}
