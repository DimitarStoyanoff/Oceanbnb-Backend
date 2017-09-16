using Oceanbnb.Models;
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
    [RoutePrefix("api/Locations")]
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

        // POST api/values
        [HttpPost]
        [Route("AddLocation")]
        public IHttpActionResult AddLocation(LocationRequestModel model)
        {
            var response = locationService.InsertLocation(model.LocationName, model.Lattitude,model.Longitude);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("{locationId}/update")]
        public IHttpActionResult UpdateShip(LocationRequestModel model, [FromUri] int locationId)
        {
            var response = locationService.UpdateLocaiton(locationId, model.LocationName, model.Lattitude, model.Longitude);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }


        [HttpDelete]
        [Route("{locationId}")]
        public IHttpActionResult DeleteShip(int locationId)
        {
            var response = locationService.DeleteLocation(locationId);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

    }
}
