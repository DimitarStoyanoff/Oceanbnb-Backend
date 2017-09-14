using AutoMapper;
using Database;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class UserService : IUserService
    {

        public UserService()
        {
            
        }

        public UserModel Insert(string userName, string email, string gender, string city, string description, string profilePhoto, string aspUserId)
        {
            using(var db = new OceanbnbDbEntities())
            {
                var id = db.Users_Insert(userName, email, gender, city, description, profilePhoto, aspUserId).SingleOrDefault();
                Users_GetById_Result userResult = db.Users_GetById(int.Parse(id.ToString())).SingleOrDefault();
                return new UserModel(userResult.UserId, userResult.UserName, userResult.Email, userResult.Gender, userResult.City, userResult.Description,
                    userResult.ProfilePhoto, userResult.AspUserId, userResult.IsDeleted);
            }
        }

        public UserModel Update(int id, string userName, string email, string gender, string city, string description, string profilePhoto, string aspUserId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                db.Users_Update(id, userName, email, gender, city, description, profilePhoto).SingleOrDefault();
                Users_GetById_Result userResult = db.Users_GetById(id).SingleOrDefault();
                return new UserModel(userResult.UserId, userResult.UserName, userResult.Email, userResult.Gender, userResult.City, userResult.Description,
                     userResult.ProfilePhoto, userResult.AspUserId, userResult.IsDeleted);
            }
        }

        public UserModel GetUser(int id)
        {
            using (var db = new OceanbnbDbEntities())
            {
                Users_GetById_Result userResult = db.Users_GetById(id).SingleOrDefault();
                return new UserModel(userResult.UserId, userResult.UserName, userResult.Email, userResult.Gender, userResult.City, userResult.Description,
                    userResult.ProfilePhoto, userResult.AspUserId, userResult.IsDeleted);
            }
        }
        
        
        public UserModel GetUserByIdentityId(string aspUserId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                Users_GetByAspId_Result userResult = db.Users_GetByAspId(aspUserId).SingleOrDefault();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Users_GetByAspId_Result, UserModel>());
                var mapper = config.CreateMapper();
                UserModel userModel = mapper.Map<UserModel>(userResult);
                userModel.AspUserId = aspUserId;
                return userModel;
            }
        }

    }
}
