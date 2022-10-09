using System;
using System.Collections.Generic;

namespace appbuscar.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public int Name { get; set; }
        public short Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
