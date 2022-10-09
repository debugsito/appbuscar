using System;
using System.Collections.Generic;

namespace appbuscar.Models
{
    public partial class Buses
    {
        public Buses()
        {
            ScheduleRoutes = new HashSet<ScheduleRoutes>();
        }

        public int Id { get; set; }
        public string Plate { get; set; } = null!;
        public int ProductionYear { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int NumberSeats { get; set; }
        public short Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<ScheduleRoutes> ScheduleRoutes { get; set; }
    }
}
