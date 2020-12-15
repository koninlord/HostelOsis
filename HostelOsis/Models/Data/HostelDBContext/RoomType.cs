using System;
using System.Collections.Generic;

namespace HostelOsis.Models.Data.HostelDBContext
{
    public partial class RoomType
    {
        public RoomType()
        {
            Room = new HashSet<Room>();
        }

        public int RoomTypeId { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
