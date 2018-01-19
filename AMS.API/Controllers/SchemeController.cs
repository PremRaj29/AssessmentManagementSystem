using AMS.API.Contracts;
using AMS.API.Core;
using AMS.API.DTO;
using AMS.API.DTO.Scheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMS.API.Controllers
{
    [RoutePrefix("api")]
    public class SchemeController : BaseApiController
    {
        #region CRUD Operations

        //Get: Scheme
        /// <summary>
        /// Get list of Scheme based on id i.e. specific or all
        /// </summary>
        /// <param name="schemeId"></param>
        /// <returns></returns>
        [Route("Scheme/{schemeId?}")]
        public IHttpActionResult Get(int schemeId = 0)
        {
            return Ok(GetSchemeDbService().GetScheme(new SchemeRequestParams() { Id = schemeId }));
        }

        //Post: Scheme
        /// <summary>
        /// Create/Add new Scheme
        /// </summary>
        /// <param name="scheme"></param>
        /// <returns></returns>
        [Route("Scheme")]
        public IHttpActionResult Post(Scheme scheme)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "POST", ServiceName = "AddScheme", RequestProcessed = false, RequestSuccessful = false };

            if (scheme != null)
            {
                if (scheme.Id == 0)
                {
                    operationStatus = GetSchemeDbService().AddScheme(scheme);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "Scheme", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use PUT method to update state of object." });
                }
            }

            return Ok(operationStatus);
        }

        //Put: Scheme
        /// <summary>
        /// Update existing Scheme
        /// </summary>
        /// <param name="scheme"></param>
        /// <param name="schemeId"></param>
        /// <returns></returns>
        [Route("Scheme/{schemeId}")]
        public IHttpActionResult Put(Scheme scheme, int schemeId = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "PUT", ServiceName = "UpdateScheme", RequestProcessed = false, RequestSuccessful = false };

            if (scheme != null)
            {
                if (schemeId > 0)
                {
                    //Comment : Here set value of schemeId into DTO object and then call Update method
                    scheme.Id = schemeId;

                    operationStatus = GetSchemeDbService().UpdateScheme(scheme);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "Scheme", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use POST method to create object." });
                }
            }

            return Ok(operationStatus);
        }

        //Delete: Scheme
        /// <summary>
        /// Remove existing Scheme
        /// </summary>
        /// <param name="schemeId"></param>
        /// <returns></returns>
        [Route("Scheme/{schemeId}")]
        public IHttpActionResult Delete(int schemeId = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "DELETE", ServiceName = "RemoveScheme", RequestProcessed = false, RequestSuccessful = false };

            if (schemeId > 0)
            {
                operationStatus = GetSchemeDbService().RemoveScheme(schemeId);
            }

            return Ok(operationStatus);
        }

        #endregion CRUD Operations

        #region Private

        private ISchemeDbService GetSchemeDbService()
        {
            ISchemeDbService service = new SchemeDbService();
            return service;
        }

        #endregion Private
    }
}
