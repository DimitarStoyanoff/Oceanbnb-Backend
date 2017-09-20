using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public partial class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string ProfilePhoto { get; set; }
        public string AspUserId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public UserModel()
        {

        }

        public UserModel(int userId, string userName, string email, string gender, string city, string description, string profilePhoto, string aspUserId, bool? isDeleted)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            Gender = gender;
            City = city;
            Description = description;
            ProfilePhoto = profilePhoto;
            AspUserId = aspUserId;
            IsDeleted = isDeleted;
        }
    }
}
