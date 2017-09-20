using AutoMapper;
using Database;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ShipService
    {
        private MapperConfiguration config;
        private IMapper mapper;

        public ShipService()
        {
            config = new MapperConfiguration(cfg => cfg.CreateMap<Ships_GetById_Result, ShipModel>());
            mapper = config.CreateMapper();
        }
        public ShipModel GetShipById(int shipId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                return mapper.Map<ShipModel>(db.Ships_GetById(shipId).SingleOrDefault());
            }
        }

        public ShipModel DeleteShip(int shipId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                db.Ships_Delete(shipId);
                return mapper.Map<ShipModel>(db.Ships_GetById(shipId).SingleOrDefault());
            }
        }

        public ShipModel UpdateShip(int shipId, string shipName, int yearBuilt, int passengerCapacity, int crewCount, int weightInTons, int lengthInMeters, int beamInMeters)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var id = db.Ships_Update(shipId, shipName, yearBuilt, passengerCapacity, crewCount, weightInTons, lengthInMeters, beamInMeters).SingleOrDefault();
                return mapper.Map<ShipModel>(db.Ships_GetById(shipId).SingleOrDefault());
            }
        }

        public ShipModel InsertShip(string shipName, int yearBuilt, int passengerCapacity, int crewCount, int weightInTons, int lengthInMeters, int beamInMeters)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var id = db.Ships_Insert(shipName, yearBuilt, passengerCapacity, crewCount, weightInTons, lengthInMeters, beamInMeters).SingleOrDefault();
                return mapper.Map<ShipModel>(db.Ships_GetById(int.Parse(id.ToString())).SingleOrDefault());
            }
        }

        public List<ShipModel> GetAllShips()
        {
            using (var db = new OceanbnbDbEntities())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Ships_GetAllShips_Result, ShipModel>());
                var mapper = config.CreateMapper();
                return mapper.Map<List<Ships_GetAllShips_Result>,List<ShipModel>>(db.Ships_GetAllShips().ToList());
            }
        }
    }
}
