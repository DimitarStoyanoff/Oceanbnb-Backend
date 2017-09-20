using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class CruiseModel
    {
        public int CruiseId { get; set; }
        public string CruiseName { get; set; }
        public int ShipId { get; set; }
        public bool IsDeleted { get; set; }
        public List<LocationModel> LocationsList { get; set; }

        public CruiseModel()
        {

        }

        public CruiseModel(int CruiseId, string CruiseName, int ShipId, bool IsDeleted, List<LocationModel> LocationsList)
        {
            this.CruiseId = CruiseId;
            this.CruiseName = CruiseName;
            this.ShipId = ShipId;
            this.IsDeleted = IsDeleted;
            this.LocationsList = LocationsList;
        }
    }
}
