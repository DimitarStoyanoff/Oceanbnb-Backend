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
    class CruiseService
    {
        public CruiseModel GetFullCruiseById(int cruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Cruises_GetById_Result, CruiseModel>());
                var locationConfig = new MapperConfiguration(cfg => cfg.CreateMap<List<Locations_GetById_Result>, List<LocationModel>>());
                var locationMapper = locationConfig.CreateMapper();
                Cruises_GetById_Result cruiseResult = db.Cruises_GetById(cruiseId).SingleOrDefault();
                var mapper = config.CreateMapper();
                CruiseModel cruise = mapper.Map<CruiseModel>(cruiseResult);
                List<LocationModel> locations =
                   mapper.Map<List<LocationModel>>(db.LocationsToCruises_GetCruiseLocations(cruiseId).ToList());
                cruise.LocationsList = locations;
                return cruise;
            }
        }

        public CruiseModel GetCruiseById(int cruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Cruises_GetById_Result, CruiseModel>());
                var mapper = config.CreateMapper();
                return mapper.Map<CruiseModel>(db.Cruises_GetById(cruiseId).SingleOrDefault());
            }
        }

        public CruiseModel InsertCruise(string cruiseName, int shipId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var id = db.Cruises_Insert(cruiseName, shipId).SingleOrDefault();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Cruises_GetById_Result, CruiseModel>());
                var mapper = config.CreateMapper();
                return mapper.Map<CruiseModel>(db.Cruises_GetById(int.Parse(id.ToString())).SingleOrDefault());
            }
        }

        public CruiseModel UpdateCruise(int cruiseId, string cruiseName, int shipId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                db.Cruises_Update(cruiseId,cruiseName, shipId).SingleOrDefault();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Cruises_GetById_Result, CruiseModel>());
                var mapper = config.CreateMapper();
                return mapper.Map<CruiseModel>(db.Cruises_GetById(cruiseId).SingleOrDefault());
            }
        }

        public CruiseModel DeleteCruise(int cruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                db.Cruises_Delete(cruiseId).SingleOrDefault();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Cruises_GetById_Result, CruiseModel>());
                var mapper = config.CreateMapper();
                return mapper.Map<CruiseModel>(db.Cruises_GetById(cruiseId).SingleOrDefault());
            }
        }

    }
}
