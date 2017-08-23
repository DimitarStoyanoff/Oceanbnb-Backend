using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Users_GetById_Result Insert(string userName, string email, string gender, string city, string description, string profilePhoto, string aspUserId);
        Users_GetById_Result Update(int id, string userName, string email, string gender, string city, string description, string profilePhoto, string aspUserId);
    }
}
