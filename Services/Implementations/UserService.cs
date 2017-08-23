using Database;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        public Users_GetById_Result Insert(string userName, string email, string gender, string city, string description, string profilePhoto, string aspUserId)
        {
            using(var db = new OceanbnbDbEntities())
            {
                var id = db.Users_Insert(userName, email, gender, city, description, profilePhoto, aspUserId).SingleOrDefault();
                return db.Users_GetById(int.Parse(id.ToString())).SingleOrDefault();
            }
        }

        public Users_GetById_Result Update(int id, string userName, string email, string gender, string city, string description, string profilePhoto, string aspUserId)
        {
            using (var db = new OceanbnbDbEntities())
            {
                db.Users_Update(id, userName, email, gender, city, description, profilePhoto).SingleOrDefault();
                return db.Users_GetById(id).SingleOrDefault();
            }
        }
    }
}
