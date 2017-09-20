using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oceanbnb.Models
{
    public class ShipRequestModel
    {
        [Required]
        public string ShipName { get; set; }
        public int YearBuilt { get; set; }
        public int PassengerCapacity { get; set; }
        public int CrewCount { get; set; }
        public int WeightInTons { get; set; }
        public int LengthInMeters { get; set; }
        public int BeamInMeters { get; set; }
        public bool IsDeleted { get; set; }
    }
}