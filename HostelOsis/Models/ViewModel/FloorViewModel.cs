using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HostelOsis.Models.ViewModel
{
    public class FloorViewModel
    {
        public int FloorID { get; set; }
        [Display(Name = "Floor Name")]
        [Required(ErrorMessage = "Select Floor")]
        public string FloorName { get; set; }
    }
}
