using AMS.API.Contracts;
using AMS.API.Core;
using AMS.API.DTO;
using AMS.API.DTO.Assessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMS.API.Controllers
{
    [RoutePrefix("api")]
    public class AssessorPreferredLocationController : BaseApiController
    {
        #region CRUD Operations

        //Get: AssessorPreferredLocation-1
        /// <summary>
        /// Get list of AssessorPreferredLocations based on AssessorPreferredLocationId i.e. specific id or all
        /// </summary>
        /// <param name="assessorPreferredLocationId"></param>
        /// <returns></returns>
        [Route("AssessorPreferredLocation/{assessorPreferredLocationId?}")]
        public IHttpActionResult Get(int assessorPreferredLocationId)
        {
            return Ok(GetAssessorPreferredLocationDbService().GetPreferredLocations(new AssessorPreferredLocationRequestParams() { Id = assessorPreferredLocationId }));
        }

        //Get: AssessorPreferredLocation-2
        /// <summary>
        /// Get list of AssessorPreferredLocation based on "Id, AssessorId, PreferredLocationId" search-type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assessorId"></param>
        /// <param name="cityId"></param>
        /// <returns></returns>
        [Route("AssessorPreferredLocation/{id?}/{assessorId}/{cityId}")]
        public IHttpActionResult Get(int assessorId, int cityId, int id = 0)
        {
            return Ok(GetAssessorPreferredLocationDbService().GetPreferredLocations(new AssessorPreferredLocationRequestParams() { Id = id, AssessorId = assessorId, CityId = cityId }));
        }


        //Post: AssessorPreferredLocation
        /// <summary>
        /// Create/Add new AssessorPreferredLocation
        /// </summary>
        /// <param name="assessor"></param>
        /// <returns></returns>
        [Route("AssessorPreferredLocation")]
        public IHttpActionResult Post(AssessorPreferredLocation assessor)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "POST", ServiceName = "AddAssessorPreferredLocation", RequestProcessed = false, RequestSuccessful = false };

            if (assessor != null)
            {
                if (assessor.Id == 0)
                {
                    operationStatus = GetAssessorPreferredLocationDbService().AddPreferredLocation(assessor);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "AssessorPreferredLocation", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use PUT method to update state of object." });
                }
            }

            return Ok(operationStatus);
        }

        //Put: AssessorPreferredLocation
        /// <summary>
        /// Update existing AssessorPreferredLocation
        /// </summary>
        /// <param name="assessorPreferredLocation"></param>
        /// <param name="assessorPreferredLocationId"></param>
        /// <returns></returns>
        [Route("AssessorPreferredLocation/{assessorPreferredLocationId}")]
        public IHttpActionResult Put(AssessorPreferredLocation assessorPreferredLocation, int assessorPreferredLocationId = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "PUT", ServiceName = "UpdateAssessorPreferredLocation", RequestProcessed = false, RequestSuccessful = false };

            if (assessorPreferredLocation != null)
            {
                if (assessorPreferredLocationId > 0)
                {
                    //Comment : Here set value of assessorPreferredLocationId into DTO object and then call Update method
                    assessorPreferredLocation.Id = assessorPreferredLocationId;

                    operationStatus = GetAssessorPreferredLocationDbService().UpdatePreferredLocation(assessorPreferredLocation);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "AssessorPreferredLocation", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use POST method to create object." });
                }
            }

            return Ok(operationStatus);
        }

        //Delete: AssessorPreferredLocation
        /// <summary>
        /// Remove existing AssessorPreferredLocation
        /// </summary>
        /// <param name="assessorId"></param>
        /// <param name="cityId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("AssessorPreferredLocation/{assessorId}/{cityId}/{id?}")]
        public IHttpActionResult Delete(int assessorId, int cityId, int id = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "DELETE", ServiceName = "RemoveAssessorPreferredLocation", RequestProcessed = false, RequestSuccessful = false };

            if (assessorId > 0)
            {
                operationStatus = GetAssessorPreferredLocationDbService().RemovePreferredLocation(assessorId,cityId,id);
            }

            return Ok(operationStatus);
        }

        #endregion CRUD Operations

        #region Private

        private IAssessorPreferredLocationDbService GetAssessorPreferredLocationDbService()
        {
            IAssessorPreferredLocationDbService service = new AssessorPreferredLocationDbService();
            return service;
        }

        #endregion Private
    }
}
