using System;
using System.Collections.Generic;

namespace Project_ITAcademy.Domain.Models
{
    public partial class User
    {
        public User()
        {
            Routes = new HashSet<Route>();
        }

        public string UserId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Route> Routes { get; set; }
    }
}
