using System;
using System.Collections.Generic;

namespace Project_ITAcademy.Domain.Models
{
    public partial class Route
    {
        public Route()
        {
            Stations = new HashSet<Station>();
            Trains = new HashSet<Train>();
        }

        public string RouteId { get; set; } = null!;
        public string? Description { get; set; }
        public string UserId { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Station> Stations { get; set; }
        public virtual ICollection<Train> Trains { get; set; }
    }
}
