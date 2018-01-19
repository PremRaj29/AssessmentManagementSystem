using AMS.API.Contracts;
using AMS.API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMS.API.Controllers
{
    [RoutePrefix("api")]
    public class GeographyController : BaseApiController
    {
        #region CRUD Operations

        //Get: State
        /// <summary>
        /// Get list of State based on id i.e. specific or all
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        [Route("Geography/State/{stateId?}")]
        public IHttpActionResult Get(int stateId = 0)
        {
            return Ok(GetGeographyDbService().GetStates(stateId));
        }

        //Get: City
        /// <summary>
        /// Get list of Cities based on state-id and city-id i.e. specific or all
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        [Route("Geography/State/{stateId}/City/{cityId?}")]
        public IHttpActionResult Get(int stateId, int cityId = 0)
        {
            return Ok(GetGeographyDbService().GetCities(stateId,cityId));
        }

        #endregion CRUD Operations

        #region Private

        private IGeographyDbService GetGeographyDbService()
        {
            IGeographyDbService service = new GeographyDbService();
            return service;
        }

        #endregion Private
    }
}
