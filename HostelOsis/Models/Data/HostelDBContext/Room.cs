using System;
using System.Collections.Generic;

namespace HostelOsis.Models.Data.HostelDBContext
{
    public partial class Room
    {
        public Room()
        {
            BookingDetails = new HashSet<BookingDetails>();
            HostelOccupant = new HashSet<HostelOccupant>();
        }

        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public int FloorId { get; set; }
        public string IsAvailable { get; set; }

        public virtual Floor Floor { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<BookingDetails> BookingDetails { get; set; }
        public virtual ICollection<HostelOccupant> HostelOccupant { get; set; }
    }
}
