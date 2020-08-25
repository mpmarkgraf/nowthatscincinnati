using System;
using System.Collections.Generic;

namespace nowthatscincinnati.Models
{
    public partial class Users
    {
        public Users()
        {
            Events = new HashSet<Events>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<Events> Events { get; set; }
    }
}
