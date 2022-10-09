using System;
using System.Collections.Generic;

namespace appbuscar.Models
{
    public partial class ScheduleRoutes
    {
        public ScheduleRoutes()
        {
            RouteTickets = new HashSet<RouteTickets>();
        }

        public int Id { get; set; }
        public int RouteId { get; set; }
        public int BusId { get; set; }
        public DateTime ScheduleStart { get; set; }
        public DateTime ScheduleEnd { get; set; }
        public int AvailableSeats { get; set; }
        public double Price { get; set; }
        public short Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Buses Bus { get; set; } = null!;
        public virtual Routes Route { get; set; } = null!;
        public virtual ICollection<RouteTickets> RouteTickets { get; set; }
    }
}
