using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oceanbnb.Models
{
    public class AddUserToCruiseRequestModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CruiseId { get; set; }
    }
}