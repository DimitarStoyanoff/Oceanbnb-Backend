using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Oceanbnb.Controllers
{
    [Authorize]
    [RoutePrefix("api/Ships")]
    public class LocationsController : ApiController
    {
        private LocationService locationService = new LocationService();

        // GET api/cruises/5
        [Route("{locationId}")]
        public IHttpActionResult Get(int locationId)
        {
            var response = locationService.GetLocationById(locationId);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }



    }
}
