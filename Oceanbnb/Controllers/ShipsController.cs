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
    [RoutePrefix("api/Ships")]
    public class ShipsController : ApiController
    {
        private ShipService shipService = new ShipService();

        // GET api/cruises/5
        [Route("{shipId}")]
        public IHttpActionResult Get(int shipId)
        {
            var response = shipService.GetShipById(shipId);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        //GET api/cruises
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var response = shipService.GetAllShips();
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("AddShip")]
        public IHttpActionResult AddShip(ShipRequestModel model)
        {
            var response = shipService.InsertShip(model.ShipName, model.YearBuilt, model.PassengerCapacity, model.CrewCount, model.WeightInTons, model.LengthInMeters, model.BeamInMeters);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("{shipId}/update")]
        public IHttpActionResult UpdateShip(ShipRequestModel model, [FromUri] int shipId)
        {
            var response = shipService.UpdateShip(shipId, model.ShipName, model.YearBuilt, model.PassengerCapacity, model.CrewCount, model.WeightInTons, model.LengthInMeters, model.BeamInMeters);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("{shipId}")]
        public IHttpActionResult DeleteShip(int shipId)
        {
            var response = shipService.DeleteShip(shipId);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
