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
    public class CruiseService
    {
        private MapperConfiguration cruiseConfig;
        private IMapper cruiseMapper;
        private MapperConfiguration locationToCruiseConfig;
        private IMapper locationToCruiseMapper;
        private MapperConfiguration userToCruiseConfig;
        private IMapper userToCruiseMapper;

        public CruiseService()
        {
            cruiseConfig = new MapperConfiguration(cfg => cfg.CreateMap<Cruises_GetById_Result, CruiseModel>());
            cruiseMapper = cruiseConfig.CreateMapper();
            locationToCruiseConfig = new MapperConfiguration(cfg => cfg.CreateMap<LocationsToCruises_GetById_Result, LocationsToCruisesModel>());
            locationToCruiseMapper = locationToCruiseConfig.CreateMapper();
            userToCruiseConfig = new MapperConfiguration(cfg => cfg.CreateMap<UsersToCruises_GetById_Result, UsersToCruisesModel>());
            userToCruiseMapper = userToCruiseConfig.CreateMapper();
        }

        public CruiseModel GetFullCruiseById(int cruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
               
                var locationConfig = new MapperConfiguration(cfg => cfg.CreateMap<List<Locations_GetById_Result>, List<LocationModel>>());
                var locationMapper = locationConfig.CreateMapper();
                Cruises_GetById_Result cruiseResult = db.Cruises_GetById(cruiseId).SingleOrDefault();
                
                CruiseModel cruise = cruiseMapper.Map<CruiseModel>(cruiseResult);
                List<LocationModel> locations =
                   locationMapper.Map<List<LocationModel>>(db.LocationsToCruises_GetCruiseLocations(cruiseId).ToList());
                cruise.LocationsList = locations;
                return cruise;
            }
        }

        public CruiseModel GetCruiseById(int cruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                return cruiseMapper.Map<CruiseModel>(db.Cruises_GetById(cruiseId).SingleOrDefault());
            }
        }

        public List<CruiseModel> GetAllCruises()
        {
            using (var db = new OceanbnbDbEntities())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<List<Cruises_GetAllCruises_Result>, List<CruiseModel>>());
                var map = config.CreateMapper();
                return cruiseMapper.Map<List<CruiseModel>>(db.Cruises_GetAllCruises().ToList());
            }
        }

        public CruiseModel InsertCruise(string cruiseName, int shipId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var id = db.Cruises_Insert(cruiseName, shipId).SingleOrDefault();
                return cruiseMapper.Map<CruiseModel>(db.Cruises_GetById(int.Parse(id.ToString())).SingleOrDefault());
            }
        }

        public CruiseModel UpdateCruise(int cruiseId, string cruiseName, int shipId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                db.Cruises_Update(cruiseId,cruiseName, shipId).SingleOrDefault();
                return cruiseMapper.Map<CruiseModel>(db.Cruises_GetById(cruiseId).SingleOrDefault());
            }
        }

        public CruiseModel DeleteCruise(int cruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                db.Cruises_Delete(cruiseId).SingleOrDefault();
                return cruiseMapper.Map<CruiseModel>(db.Cruises_GetById(cruiseId).SingleOrDefault());
            }
        }

        public LocationsToCruisesModel InsertLocationToCruise(int locationId, int cruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var id = db.LocationsToCruises_InsertUpdate(0, locationId, cruiseId, false).SingleOrDefault();
                return locationToCruiseMapper.Map<LocationsToCruisesModel>(db.LocationsToCruises_GetById(int.Parse(id.ToString())));
            }
        }

        public LocationsToCruisesModel UpdateLocationToCruise(int locationToCruiseId,int locationId, int cruiseId, bool isDeleted)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var id = db.LocationsToCruises_InsertUpdate(locationToCruiseId, locationId, cruiseId, isDeleted).SingleOrDefault();
                return locationToCruiseMapper.Map<LocationsToCruisesModel>(db.LocationsToCruises_GetById(int.Parse(id.ToString())));
            }
        }

        public LocationsToCruisesModel GetLocationToCruise(int locationToCruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var id = db.LocationsToCruises_GetById(locationToCruiseId).SingleOrDefault();
                return locationToCruiseMapper.Map<LocationsToCruisesModel>(db.LocationsToCruises_GetById(int.Parse(id.ToString())));
            }
        }

        public LocationsToCruisesModel DeleteLocationToCruise(int locationToCruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var id = db.LocationsToCruises_Delete(locationToCruiseId).SingleOrDefault();
                return locationToCruiseMapper.Map<LocationsToCruisesModel>(db.LocationsToCruises_GetById(int.Parse(id.ToString())));
            }
        }

        public List<UsersToCruisesModel> GetUserCruises(int cruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<List<UsersToCruises_GetById_Result>, List<UsersToCruisesModel>>());
                var mapper = config.CreateMapper();
                return mapper.Map<List<UsersToCruisesModel>>(db.UsersToCruises_GetUserCruises(cruiseId).ToList());
            }
        }

       
        public UsersToCruisesModel InsertCruiseUser(int userId,int cruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                return userToCruiseMapper.Map<UsersToCruisesModel>(db.UsersToCruises_InsertUpdate(0,userId,cruiseId,false).SingleOrDefault());
            }
        }

        public UsersToCruisesModel UpdateCruiseUser(int userToCruiseId,int userId, int cruiseId, bool isDeleted)
        {
            using (var db = new OceanbnbDbEntities())
            {
                return userToCruiseMapper.Map<UsersToCruisesModel>(db.UsersToCruises_InsertUpdate(userToCruiseId, userId, cruiseId, isDeleted).SingleOrDefault());
            }
        }

    }
}
