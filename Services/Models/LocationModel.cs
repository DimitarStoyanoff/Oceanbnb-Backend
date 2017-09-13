using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class LocationModel
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public bool IsDeleted { get; set; }

        public LocationModel(int LocationId, string LocationName, double Lattitude, double Longitude, bool IsDeleted)
        {
            this.LocationId = LocationId;
            this.LocationName = LocationName;
            this.Lattitude = Lattitude;
            this.Longitude = Longitude;
            this.IsDeleted = IsDeleted;
        }
    }
}
