using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ShipModel
    {
        public int ShipId { get; set; }
        public string ShipName { get; set; }
        public int YearBuilt { get; set; }
        public int PassengerCapacity { get; set; }
        public int CrewCount { get; set; }
        public int WeightInTons { get; set; }
        public int LengthInMeters { get; set; }
        public int BeamInMeters { get; set; }
        public bool IsDeleted { get; set; }

        public ShipModel()
        {

        }

        public ShipModel(int shipId, string shipName, int yearBuilt, int passengerCapacity, int crewCount, int weightInTons, int lengthInMeters, int beamInMeters, bool isDeleted)
        {
            ShipId = shipId;
            ShipName = shipName;
            YearBuilt = yearBuilt;
            PassengerCapacity = passengerCapacity;
            CrewCount = crewCount;
            WeightInTons = weightInTons;
            LengthInMeters = lengthInMeters;
            BeamInMeters = beamInMeters;
            IsDeleted = isDeleted;
        }
    }
}
