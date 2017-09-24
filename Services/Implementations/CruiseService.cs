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
               
                var locationConfig = new MapperConfiguration(cfg => cfg.CreateMap<LocationsToCruises_GetCruiseLocations_Result, LocationModel>());
                var locationMapper = locationConfig.CreateMapper();
                Cruises_GetById_Result cruiseResult = db.Cruises_GetById(cruiseId).SingleOrDefault();
                
                CruiseModel cruise = cruiseMapper.Map<CruiseModel>(cruiseResult);
                List<LocationModel> locations =
                   locationMapper.Map<List<LocationsToCruises_GetCruiseLocations_Result>,List<LocationModel>>(db.LocationsToCruises_GetCruiseLocations(cruiseId).ToList());
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
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Cruises_GetAllCruises_Result, CruiseModel>());
                var map = config.CreateMapper();
                return map.Map<List<Cruises_GetAllCruises_Result>, List<CruiseModel>>(db.Cruises_GetAllCruises().ToList());
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
                var id = db.LocationsToCruises_InsertUpdate(locationId, cruiseId, false).SingleOrDefault();
                return locationToCruiseMapper.Map<LocationsToCruisesModel>(db.LocationsToCruises_GetById(int.Parse(id.ToString())).SingleOrDefault());
            }
        }

        public bool UpdateLocationToCruise(int locationId, int cruiseId, bool isDeleted)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var id = db.LocationsToCruises_InsertUpdate(locationId, cruiseId, isDeleted).SingleOrDefault();
                return true;
            }
        }

        public LocationsToCruisesModel GetLocationToCruise(int locationToCruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var id = db.LocationsToCruises_GetById(locationToCruiseId).SingleOrDefault();
                return locationToCruiseMapper.Map<LocationsToCruisesModel>(db.LocationsToCruises_GetById(int.Parse(id.ToString())).SingleOrDefault());
            }
        }

        public LocationsToCruisesModel DeleteLocationToCruise(int locationToCruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var id = db.LocationsToCruises_Delete(locationToCruiseId).SingleOrDefault();
                return locationToCruiseMapper.Map<LocationsToCruisesModel>(db.LocationsToCruises_GetById(int.Parse(id.ToString())).SingleOrDefault());
            }
        }

        public List<UsersToCruisesModel> GetUserCruises(string aspUserId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UsersToCruises_GetUserCruises_Result, UsersToCruisesModel>());
                var mapper = config.CreateMapper();
                return mapper.Map<List<UsersToCruises_GetUserCruises_Result>, List<UsersToCruisesModel>>(db.UsersToCruises_GetUserCruises(aspUserId).ToList());
            }
        }

        public List<CruiseUsersModel> GetCruiseUsers(int cruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UsersToCruises_GetCruiseUsers_Result, CruiseUsersModel>());
                var mapper = config.CreateMapper();
                return mapper.Map<List<UsersToCruises_GetCruiseUsers_Result>, List<CruiseUsersModel>>(db.UsersToCruises_GetCruiseUsers(cruiseId).ToList());
            }

        }

       
        public UsersToCruisesModel InsertCruiseUser(int userId,int cruiseId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                return userToCruiseMapper.Map<UsersToCruisesModel>(db.UsersToCruises_InsertUpdate(userId,cruiseId,false).SingleOrDefault());
            }
        }

        public bool UpdateCruiseUser(int userId, int cruiseId, bool isDeleted)
        {
            using (var db = new OceanbnbDbEntities())
            {
                db.UsersToCruises_InsertUpdate( userId, cruiseId, isDeleted).SingleOrDefault();
                return true;
            }
        }

    }
}
