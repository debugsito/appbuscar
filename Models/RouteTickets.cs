using System;
using System.Collections.Generic;

namespace appbuscar.Models
{
    public partial class RouteTickets
    {
        public int Id { get; set; }
        public int ScheduleRouteId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public int NumberSeat { get; set; }
        public short Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ScheduleRoutes ScheduleRoute { get; set; } = null!;
        public virtual Users User { get; set; } = null!;
    }
}
