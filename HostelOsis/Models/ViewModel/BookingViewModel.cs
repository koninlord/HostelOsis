using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HostelOsis.Models.ViewModel
{
    public class BookingViewModel
    {
        public int BillID { get; set; }
        [Display(Name ="Start Date")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:yyyy-MM-dd HH:mm}")]
        [Required(ErrorMessage = "Select Date")]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Departure Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [Required(ErrorMessage = "Select departure date")]
        public DateTime DepartureDate { get; set; }
        [Display(Name = "Room Number")]
        [Required(ErrorMessage = "Select Room ")]
        public int RoomID { get; set; }
    
        public decimal Price { get; set; }
      
        [Display(Name = "Room Number")]
        [Required(ErrorMessage = "Select Room ")]
        public int RoomNumber { get; set; }
        public string IsAvailable { get; set; }


        public SelectList RoomList { get; set; }
       // public SelectList NumberList { get; set; }
       // public SelectList AvailableList { get; set; }

    }
}
