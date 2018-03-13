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
    public class AssessorController : BaseApiController
    {
        #region CRUD Operations

        //Get: Assessor-1
        /// <summary>
        /// Get list of Assessor based on AssessorId i.e. specific id or all
        /// </summary>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        [Route("Assessor/{assessorId?}")]
        public IHttpActionResult Get(int assessorId)
        {
            return Ok(GetAssessorDbService().GetAssessor(new AssessorRequestParams() { AssessorId = assessorId }));
        }

        //Get: Assessor-2
        /// <summary>
        /// Get list of Assessor based on "AssessorId or IRIS_Id" search-type
        /// </summary>
        /// <param name="assessorId"></param>
        /// <param name="iris_Id"></param>
        /// <returns></returns>
        [Route("Assessor/{assessorId?}/{iris_Id?}")]
        public IHttpActionResult Get(int assessorId = 0, string iris_Id = null)
        {
            return Ok(GetAssessorDbService().GetAssessor(new AssessorRequestParams() { AssessorId = assessorId, IRIS_Id = iris_Id }));
        }

        //Get: SearchJobRoles
        [Route("Assessor/Search")]
        [HttpPost]
        public IHttpActionResult SearchAssessor([FromUri]SearchAssessorRequestParams searchParams)
        {
            if (searchParams == null)
            {
                searchParams = new SearchAssessorRequestParams();
            }

            return Ok(GetAssessorDbService().SearchAssessors(searchParams));
        }


        //Post: Assessor
        /// <summary>
        /// Create/Add new Assessor
        /// </summary>
        /// <param name="assessor"></param>
        /// <returns></returns>
        [Route("Assessor")]
        public IHttpActionResult Post(Assessor assessor)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "POST", ServiceName = "AddAssessor", RequestProcessed = false, RequestSuccessful = false };

            if (assessor != null)
            {
                if (assessor.Id == 0)
                {
                    operationStatus = GetAssessorDbService().AddAssessor(assessor);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "Assessor", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use PUT method to update state of object." });
                }
            }

            return Ok(operationStatus);
        }

        //Put: Assessor
        /// <summary>
        /// Update existing Assessor
        /// </summary>
        /// <param name="assessor"></param>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        [Route("Assessor/{assessorId}")]
        public IHttpActionResult Put(Assessor assessor, int assessorId = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "PUT", ServiceName = "UpdateAssessor", RequestProcessed = false, RequestSuccessful = false };

            if (assessor != null)
            {
                if (assessorId > 0)
                {
                    //Comment : Here set value of assessorId into DTO object and then call Update method
                    assessor.Id = assessorId;

                    operationStatus = GetAssessorDbService().UpdateAssessor(assessor);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "Assessor", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use POST method to create object." });
                }
            }

            return Ok(operationStatus);
        }

        //Delete: Assessor
        /// <summary>
        /// Remove existing Assessor
        /// </summary>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        [Route("Assessor/{assessorId}")]
        public IHttpActionResult Delete(int assessorId = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "DELETE", ServiceName = "RemoveAssessor", RequestProcessed = false, RequestSuccessful = false };

            if (assessorId > 0)
            {
                operationStatus = GetAssessorDbService().RemoveAssessor(assessorId);
            }

            return Ok(operationStatus);
        }

        #endregion CRUD Operations

        #region Private

        private IAssessorDemographicDbService GetAssessorDbService()
        {
            IAssessorDemographicDbService service = new AssessorDemographicDbService();
            return service;
        }

        #endregion Private
    }
}
