using System;
using System.Collections.Generic;

namespace Project_ITAcademy.Domain.Models
{
    public partial class Train
    {
        public string TrainId { get; set; } = null!;
        public double Coordinate1 { get; set; }
        public double Coordinate2 { get; set; }
        public string? Description { get; set; }
        public string RouteId { get; set; } = null!;

        public virtual Route Route { get; set; } = null!;
    }
}
