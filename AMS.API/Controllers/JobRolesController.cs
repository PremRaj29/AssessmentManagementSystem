using AMS.API.Contracts;
using AMS.API.Core;
using AMS.API.DTO;
using AMS.API.DTO.JobRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMS.API.Controllers
{
    [RoutePrefix("api")]
    public class JobRolesController : BaseApiController
    {
        #region CRUD Operations

        //Get: JobRoles
        /// <summary>
        /// Get JobRoles for supplied skill-coucil
        /// </summary>
        /// <param name="skillCouncilId"></param>
        /// <param name="jobRoleId"></param>
        /// <returns></returns>
        [Route("SkillCouncil/{skillCouncilId?}/JobRole/{jobRoleId?}")]
        public IHttpActionResult Get(int skillCouncilId = 0,int jobRoleId = 0)
        {
            return Ok(GetJobRolesDbService().GetJobRoles(new JobRoleRequestParams() { JobRoleId = jobRoleId, SkillCouncilId = skillCouncilId }));
        }

        //Get: SearchJobRoles
        [Route("SkillCouncil/JobRole/Search")]
        public IHttpActionResult GetSearchedJobRoles([FromUri]SearchJobRolesRequestParams searchParams)
        {
            if(searchParams == null)
            {
                searchParams = new SearchJobRolesRequestParams();
            }

            return Ok(GetJobRolesDbService().SearchJobRoles(searchParams));
        }

        //Post: JobRoles
        /// <summary>
        /// Create/Add new JobRole
        /// </summary>
        /// <param name="jobRole"></param>
        /// <param name="skillCouncilId"></param>
        /// <returns></returns>
        [Route("SkillCouncil/{skillCouncilId}/JobRole")]
        public IHttpActionResult Post(JobRole jobRole, int skillCouncilId)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "POST", ServiceName = "AddJobRole", RequestProcessed = false, RequestSuccessful = false };

            if (jobRole != null)
            {
                if (jobRole.Id == 0 && skillCouncilId > 0)
                {
                    //Comment : Here set value of skillCouncilId into DTO object and then call Add/Create method
                    jobRole.SkillCouncilId = skillCouncilId;

                    operationStatus = GetJobRolesDbService().AddJobRoles(jobRole);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "JobRole", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use PUT method to update state of object." });
                }
            }

            return Ok(operationStatus);
        }

        //Put: JobRoles
        /// <summary>
        /// Update existing JobRole
        /// </summary>
        /// <param name="jobRole"></param>
        /// <param name="skillCouncilId"></param>
        /// <param name="jobRoleId"></param>
        /// <returns></returns>
        [Route("SkillCouncil/{skillCouncilId}/JobRole/{jobRoleId}")]
        public IHttpActionResult Put(JobRole jobRole, int skillCouncilId, int jobRoleId)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "PUT", ServiceName = "UpdateJobRole", RequestProcessed = false, RequestSuccessful = false };

            if (jobRole != null)
            {
                if (jobRoleId > 0 && skillCouncilId > 0)
                {
                    //Comment : Here set value of skillCouncilId & jobRoleId into DTO object and then call Update method
                    jobRole.Id = jobRoleId;
                    jobRole.SkillCouncilId = skillCouncilId;

                    operationStatus = GetJobRolesDbService().UpdateJobRoles(jobRole);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "JobRole", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use POST method to create object." });
                }
            }

            return Ok(operationStatus);
        }

        //Delete: JobRoles
        /// <summary>
        /// Remove existing JobRole
        /// </summary>
        /// <param name="skillCouncilId"></param>
        /// <param name="jobRoleId"></param>
        /// <returns></returns>
        [Route("SkillCouncil/{skillCouncilId}/JobRole/{jobRoleId}")]
        public IHttpActionResult Delete(int skillCouncilId, int jobRoleId)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "DELETE", ServiceName = "RemoveJobRole", RequestProcessed = false, RequestSuccessful = false };

            if (skillCouncilId >0 && jobRoleId > 0)
            {
                operationStatus = GetJobRolesDbService().RemoveJobRoles(skillCouncilId,jobRoleId);
            }

            return Ok(operationStatus);
        }

        #endregion CRUD Operations

        #region Private

        private IJobRolesDbService GetJobRolesDbService()
        {
            IJobRolesDbService service = new JobRolesDbService();
            return service;
        }

        #endregion Private
    }
}
