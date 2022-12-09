using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Project_ITAcademy.Domain.Models
{
    public partial class Route
    {
        public Route()
        {
            Trains = new HashSet<Train>();
        }

        public int RouteId { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public double StartPoint { get; set; }
        public double EndPoint { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Train> Trains { get; set; }
    }
}
