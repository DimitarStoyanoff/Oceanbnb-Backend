using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class UsersToCruisesModel
    {
        public int UsersToCruisesId { get; set; }
        public int UserId { get; set; }
        public int CruiseId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateInserted { get; set; }
        public DateTime DateModified { get; set; }

        public UsersToCruisesModel()
        {

        }

        public UsersToCruisesModel(int usersToCruisesId, int userId, int cruiseId, bool isDeleted, DateTime dateInserted, DateTime dateModified)
        {
            UsersToCruisesId = usersToCruisesId;
            UserId = userId;
            CruiseId = cruiseId;
            IsDeleted = isDeleted;
            DateInserted = dateInserted;
            DateModified = dateModified;
        }
    }
}
