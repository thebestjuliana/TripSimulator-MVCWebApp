using System;
using System.Collections.Generic;

#nullable disable

namespace TripSimulator.Models
{
    public partial class Trip
    {
        public int TripId { get; set; }
        public int CarId { get; set; }
        public int Duration { get; set; }
        public int Miles { get; set; }
        public bool RoundTrip { get; set; }

        public virtual Car Car { get; set; }
    }
}
