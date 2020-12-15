using System;
using System.Collections.Generic;

namespace HostelOsis.Models.Data.HostelDBContext
{
    public partial class HostelOccupant
    {
        public int OccupantId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public int PhoneNumber { get; set; }
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
