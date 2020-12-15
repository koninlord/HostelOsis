using System;
using System.Collections.Generic;

namespace HostelOsis.Models.Data.HostelDBContext
{
    public partial class Floor
    {
        public Floor()
        {
            Room = new HashSet<Room>();
        }

        public int FloorId { get; set; }
        public string FloorName { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
