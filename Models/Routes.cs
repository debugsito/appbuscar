using System;
using System.Collections.Generic;

namespace appbuscar.Models
{
    public partial class Routes
    {
        public Routes()
        {
            ScheduleRoutes = new HashSet<ScheduleRoutes>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string StationStart { get; set; } = null!;
        public string StationEnd { get; set; } = null!;
        public double? Price { get; set; }
        public short Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<ScheduleRoutes> ScheduleRoutes { get; set; }
    }
}
