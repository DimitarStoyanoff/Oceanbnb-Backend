using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class LocationsToCruisesModel
    {
        public int LocationstoCruisesId { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public int CruiseId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateInserted { get; set; }
        public DateTime DateModified { get; set; }

        public LocationsToCruisesModel()
        {

        }

        public LocationsToCruisesModel(int locationstoCruisesId, int locationId, int cruiseId, bool isDeleted, DateTime dateInserted, DateTime dateModified)
        {
            LocationstoCruisesId = locationstoCruisesId;
            LocationId = locationId;
            CruiseId = cruiseId;
            IsDeleted = isDeleted;
            DateInserted = dateInserted;
            DateModified = dateModified;
        }


    }
}
