using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Services.Implementations;
using Services.Models;
using Oceanbnb.Models;

namespace Oceanbnb.Controllers
{
    [Authorize]
    [RoutePrefix("api/Cruises")]
    public class CruiseController : ApiController
    {
        private CruiseService cruiseService = new CruiseService();

        // GET api/cruises/5
        [Route("{cruiseId}")]
        public IHttpActionResult Get(int cruiseId)
        {
            var response = cruiseService.GetCruiseById(cruiseId);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        // GET api/criuses/5/details
        [Route("{cruiseId}/details")]
        public IHttpActionResult GetDetails(int cruiseId)
        {
            var response = cruiseService.GetFullCruiseById(cruiseId);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        // GET api/criuses/5/details
        [Route("{cruiseId}/users")]
        public IHttpActionResult GetCruiseUsers(int cruiseId)
        {
            var response = cruiseService.GetCruiseUsers(cruiseId);
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
            var response = cruiseService.GetAllCruises();
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("AddCruise")]
        public IHttpActionResult AddCruise(CruiseRequestModel model)
        {
            var response = cruiseService.InsertCruise(model.CruiseName, model.ShipId);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("AddLocation")]
        public IHttpActionResult AddLocationToCruise(LocationToCruiseRequestModel model)
        {
            var response = cruiseService.UpdateLocationToCruise(model.LocationId,model.CruiseId,false);
            if (!response)
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpPost]
        [Route("RemoveLocation")]
        public IHttpActionResult RemoveLocationFromCruise(LocationToCruiseRequestModel model)
        {
            var response = cruiseService.UpdateLocationToCruise(model.LocationId, model.CruiseId, true);
            if (!response)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        [Route("AddUser")]
        public IHttpActionResult AddUserToCruise(AddUserToCruiseRequestModel model)
        {
            var response = cruiseService.UpdateCruiseUser(model.UserId, model.CruiseId, false);
            if (!response)
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpPost]
        [Route("RemoveUser")]
        public IHttpActionResult RemoveUserFromCruise(AddUserToCruiseRequestModel model)
        {
            var response = cruiseService.UpdateCruiseUser(model.UserId, model.CruiseId, true);
            if (!response)
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpPut]
        [Route("{cruiseId}/update")]
        public IHttpActionResult UpdateShip(CruiseRequestModel model, [FromUri] int cruiseId)
        {
            var response = cruiseService.UpdateCruise(cruiseId,model.CruiseName, model.ShipId);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }


        [HttpDelete]
        [Route("{cruiseId}")]
        public IHttpActionResult DeleteShip(int cruiseId)
        {
            var response = cruiseService.DeleteCruise(cruiseId);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

    }
}
