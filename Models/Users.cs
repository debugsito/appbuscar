using System;
using System.Collections.Generic;

namespace appbuscar.Models
{
    public partial class Users
    {
        public Users()
        {
            RouteTickets = new HashSet<RouteTickets>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RolId { get; set; }
        public short Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Roles Rol { get; set; } = null!;
        public virtual ICollection<RouteTickets> RouteTickets { get; set; }
    }
}
