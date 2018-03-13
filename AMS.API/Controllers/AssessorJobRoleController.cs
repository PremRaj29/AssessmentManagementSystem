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
    public class AssessorJobRoleController : BaseApiController
    {
        #region CRUD Operations

        //Get: AssessorJobRole-1
        /// <summary>
        /// Get list of AssessorJobRoles based on AssessorJobRoleId i.e. specific id or all
        /// </summary>
        /// <param name="assessorJobRoleId"></param>
        /// <returns></returns>
        [Route("AssessorJobRole/{assessorJobRoleId?}")]
        public IHttpActionResult Get(int assessorJobRoleId)
        {
            return Ok(GetAssessorJobRoleDbService().GetJobRoles(new AssessorJobRoleRequestParams() { Id = assessorJobRoleId }));
        }

        //Get: AssessorJobRole-2
        /// <summary>
        /// Get list of AssessorJobRole based on "Id, AssessorId, JobRoleId" search-type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assessorId"></param>
        /// <param name="jobRoleId"></param>
        /// <returns></returns>
        [Route("AssessorJobRole/{id?}/{assessorId}/{jobRoleId}")]
        public IHttpActionResult Get(int assessorId, int jobRoleId, int id = 0)
        {
            return Ok(GetAssessorJobRoleDbService().GetJobRoles(new AssessorJobRoleRequestParams() { Id =  id,AssessorId = assessorId, JobRoleId = jobRoleId }));
        }


        //Post: AssessorJobRole
        /// <summary>
        /// Create/Add new AssessorJobRole
        /// </summary>
        /// <param name="assessor"></param>
        /// <returns></returns>
        [Route("AssessorJobRole")]
        public IHttpActionResult Post(AssessorJobRole assessor)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "POST", ServiceName = "AddAssessorJobRole", RequestProcessed = false, RequestSuccessful = false };

            if (assessor != null)
            {
                if (assessor.AssessorId >0 && assessor.JobRoleId >0)
                {
                    operationStatus = GetAssessorJobRoleDbService().AddJobRole(assessor);
                }
                //else
                //{
                //    operationStatus.Messages.Add(new Message() { DTOName = "AssessorJobRole", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use PUT method to update state of object." });
                //}
            }

            return Ok(operationStatus);
        }

        //Put: AssessorJobRole
        /// <summary>
        /// Update existing AssessorJobRole
        /// </summary>
        /// <param name="assessorJobRole"></param>
        /// <param name="assessorJobRoleId"></param>
        /// <returns></returns>
        [Route("AssessorJobRole/{assessorJobRoleId}")]
        public IHttpActionResult Put(AssessorJobRole assessorJobRole, int assessorJobRoleId = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "PUT", ServiceName = "UpdateAssessorJobRole", RequestProcessed = false, RequestSuccessful = false };

            if (assessorJobRole != null)
            {
                if (assessorJobRole.AssessorId >0 && assessorJobRoleId > 0)
                {
                    //Comment : Here set value of assessorJobRoleId into DTO object and then call Update method
                    assessorJobRole.Id = assessorJobRoleId;

                    operationStatus = GetAssessorJobRoleDbService().UpdateJobRole(assessorJobRole);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "AssessorJobRole", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use POST method to create object." });
                }
            }

            return Ok(operationStatus);
        }

        //Delete: AssessorJobRole
        /// <summary>
        /// Remove existing AssessorJobRole
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        [Route("AssessorJobRole/{assessorId}/{jobRoleId}/{id?}")]
        public IHttpActionResult Delete(int assessorId,int jobRoleId, int id = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "DELETE", ServiceName = "RemoveAssessorJobRole", RequestProcessed = false, RequestSuccessful = false };

            if (assessorId > 0)
            {
                operationStatus = GetAssessorJobRoleDbService().RemoveJobRole(assessorId,jobRoleId,id);
            }

            return Ok(operationStatus);
        }

        #endregion CRUD Operations

        #region Private

        private IAssessorJobRoleDbService GetAssessorJobRoleDbService()
        {
            IAssessorJobRoleDbService service = new AssessorJobRoleDbService();
            return service;
        }

        #endregion Private
    }
}
