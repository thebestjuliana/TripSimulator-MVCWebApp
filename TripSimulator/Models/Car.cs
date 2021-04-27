using System;
using System.Collections.Generic;

#nullable disable

namespace TripSimulator.Models
{
    public partial class Car
    {
        public Car()
        {
            Trips = new HashSet<Trip>();
        }

        public int CarId { get; set; }
        public int Mpg { get; set; }
        public int TankSize { get; set; }
        public string CarName { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
