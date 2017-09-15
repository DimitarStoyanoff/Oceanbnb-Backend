using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oceanbnb.Models
{
    public class CruiseRequestModel
    {
        [Required]
        public string CruiseName { get; set; }
        [Required]
        public int ShipId { get; set; }
    }
}