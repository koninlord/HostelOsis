using System;
using System.Collections.Generic;

namespace HostelOsis.Models.Data.HostelDBContext
{
    public partial class BookingDetails
    {
        public int BillId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int RoomId { get; set; }
        public decimal Price { get; set; }

        public virtual Room Room { get; set; }
    }
}
