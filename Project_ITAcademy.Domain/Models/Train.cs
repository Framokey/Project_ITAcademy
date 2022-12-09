using System;
using System.Collections.Generic;

namespace Project_ITAcademy.Domain.Models
{
    public partial class Train
    {
        public Train()
        {
            Points = new HashSet<Point>();
        }

        public int TrainId { get; set; }
        public string? Description { get; set; }
        public int RouteId { get; set; }

        public virtual Route Route { get; set; } = null!;
        public virtual ICollection<Point> Points { get; set; }
    }
}
