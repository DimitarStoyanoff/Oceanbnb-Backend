using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class CruiseUsersModel
    {
        public int UsersToCruisesId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string ProfilePhoto { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateInserted { get; set; }
        public DateTime DateModified { get; set; }

    }
}
