using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oceanbnb.Models
{
    public class LocationRequestModel
    {
        [Required]
        public string LocationName { get; set; }
        [Required]
        public double Lattitude { get; set; }
        [Required]
        public double Longitude { get; set; }
    }
}