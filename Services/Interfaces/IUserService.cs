using Database;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        UserModel Insert(string userName, string email, string gender, string city, string description, string profilePhoto, string aspUserId);
        UserModel Update(int id, string userName, string email, string gender, string city, string description, string profilePhoto, string aspUserId);
    }
}
