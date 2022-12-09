using System;
using System.Collections.Generic;

namespace Project_ITAcademy.Domain.Models
{
    public partial class Point
    {
        public int PointId { get; set; }
        public int TrainId { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }

        public virtual Train Train { get; set; } = null!;
    }
}
