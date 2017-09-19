using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oceanbnb.Models
{
    public class LocationToCruiseRequestModel
    {
        [Required]
        public int LocationId { get; set; }
        [Required]
        public int CruiseId { get; set; }
    }
}