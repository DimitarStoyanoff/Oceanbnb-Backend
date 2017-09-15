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
    public class LocationService
    {
        private MapperConfiguration config;
        private IMapper mapper;

        public LocationService()
        {
             config = new MapperConfiguration(cfg => cfg.CreateMap<Locations_GetById_Result, LocationModel>());
             mapper = config.CreateMapper();
        }

        public LocationModel GetLocationById(int locationId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                return mapper.Map<LocationModel>(db.Locations_GetById(locationId).SingleOrDefault());
            }
        }

        public LocationModel InsertLocation(string locationName, float lattitude, float longitude)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var id = db.Locations_Insert(locationName, lattitude, longitude).SingleOrDefault();  
                return mapper.Map<LocationModel>(db.Locations_GetById(int.Parse(id.ToString())).SingleOrDefault());

            }
        }

        public LocationModel UpdateLocaiton(int locationId, string locationName, float lattitude, float longitude)
        {
            using (var db = new OceanbnbDbEntities())
            {
                db.Locations_Update(locationId, locationName, lattitude, longitude).SingleOrDefault();
                return mapper.Map<LocationModel>(db.Locations_GetById(locationId).SingleOrDefault());

            }
        }

        public LocationModel DeleteLocation(int locationId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var id = db.Locations_Delete(locationId);
                return mapper.Map<LocationModel>(db.Locations_GetById(locationId).SingleOrDefault());
            }
        }
    }
}
