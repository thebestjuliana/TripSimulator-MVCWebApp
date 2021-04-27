using System;
using System.Collections.Generic;

#nullable disable

namespace TripSimulator.Models
{
    public partial class Purchase
    {
        public int PurchaseId { get; set; }
        public string Description { get; set; }
        public bool BusinessOrPersonal { get; set; }
    }
}
