using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HostelOsis.Models.ViewModel
{
    public class OccupantViewModel
    {
        public int OccupantID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field Cant be empty")]
        public string Firstname { get; set; }
        [Display(Name = "Surname")]
        [Required(ErrorMessage = "This field Cant be empty")]
        public string Surname { get; set; }
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "This field Cant be empty")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }
        
        public string Gender { get; set; }
        [Display(Name = "Marital Status")]
        [Required(ErrorMessage = "This field Cant be empty")]
        public string MaritalStatus { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "This field Cant be empty")]
        public int PhoneNumber { get; set; }
        [Display(Name = "Room Number")]
        [Required(ErrorMessage = "This field Cant be empty")]
        public int  RoomID { get; set; }
        [Display(Name = "Room Number")]
        [Required(ErrorMessage = "This field Cant be empty")]
        public int RoomNumber { get; set; }
        public string IsAvailable { get; set; }


       
        public SelectList RoomList { get; set; }
    }
}
