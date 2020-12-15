using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HostelOsis.Models.ViewModel
{
    public class RoomTypeViewModel
    {
        public int RoomTypeID { get; set; }
        [Required(ErrorMessage = "Select Type")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Select Capacity")]
        public int Capacity { get; set; }
    }
}
