using AMS.API.Contracts;
using AMS.API.Core;
using AMS.API.DTO;
using AMS.API.DTO.SkillCouncil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMS.API.Controllers
{
    [RoutePrefix("api")]
    public class SkillCouncilController : BaseApiController
    {
        #region CRUD Operations

        //Get: SkillCouncil
        /// <summary>
        /// Get SkillCouncil for supplied council-type
        /// </summary>
        /// <param name="skillCouncilId"></param>
        /// <param name="skillCouncilId"></param>
        /// <returns></returns>
        [Route("CouncilType/{councilTypeId?}/SkillCouncil/{skillCouncilId?}")]
        public IHttpActionResult Get(int councilTypeId = 0, int skillCouncilId = 0)
        {
            return Ok(GetSkillCouncilDbService().GetSkillCouncil(new SkillCouncilRequestParams() { CouncilTypeId = councilTypeId, SkillCouncilId = skillCouncilId }));
        }

        //Get: SearchSkillCouncil
        [Route("CouncilType/SkillCouncil/Search")]
        public IHttpActionResult GetSearchedSkillCouncils([FromUri]SearchSkillCouncilsRequestParams searchParams)
        {
            if (searchParams == null)
            {
                searchParams = new SearchSkillCouncilsRequestParams();
            }

            return Ok(GetSkillCouncilDbService().SearchSkillCouncils(searchParams));
        }

        //Post: SkillCouncil
        /// <summary>
        /// Create/Add new SkillCouncil
        /// </summary>
        /// <param name="skillCouncil"></param>
        /// <param name="councilTypeId"></param>
        /// <returns></returns>
        [Route("CouncilType/{councilTypeId}/SkillCouncil")]
        public IHttpActionResult Post(SkillCouncil skillCouncil, int councilTypeId)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "POST", ServiceName = "AddSkillCouncil", RequestProcessed = false, RequestSuccessful = false };

            if (skillCouncil != null)
            {
                if (skillCouncil.Id == 0 && councilTypeId > 0)
                {
                    //Comment : Here set value of skillCouncilId into DTO object and then call Add/Create method
                    skillCouncil.CouncilTypeId = councilTypeId;

                    operationStatus = GetSkillCouncilDbService().AddSkillCouncil(skillCouncil);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "SkillCouncil", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use PUT method to update state of object." });
                }
            }

            return Ok(operationStatus);
        }

        //Put: SkillCouncil
        /// <summary>
        /// Update existing SkillCouncil
        /// </summary>
        /// <param name="skillCouncil"></param>
        /// <param name="councilTypeId"></param>
        /// <param name="skillCouncilId"></param>
        /// <returns></returns>
        [Route("CouncilType/{councilTypeId}/SkillCouncil/{skillCouncilId}")]
        public IHttpActionResult Put(SkillCouncil skillCouncil, int councilTypeId, int skillCouncilId)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "PUT", ServiceName = "UpdateSkillCouncil", RequestProcessed = false, RequestSuccessful = false };

            if (skillCouncil != null)
            {
                if (councilTypeId > 0 && skillCouncilId > 0)
                {
                    //Comment : Here set value of councilTypeId & skillCouncilId into DTO object and then call Update method
                    skillCouncil.Id = skillCouncilId;
                    skillCouncil.CouncilTypeId = councilTypeId;

                    operationStatus = GetSkillCouncilDbService().UpdateSkillCouncil(skillCouncil);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "SkillCouncil", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use POST method to create object." });
                }
            }

            return Ok(operationStatus);
        }

        //Delete: SkillCouncil
        /// <summary>
        /// Remove existing SkillCouncil
        /// </summary>
        /// <param name="councilTypeId"></param>
        /// <param name="skillCouncilId"></param>
        /// <returns></returns>
        [Route("CouncilType/{councilTypeId}/SkillCouncil/{skillCouncilId}")]
        public IHttpActionResult Delete(int councilTypeId, int skillCouncilId)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "DELETE", ServiceName = "RemoveSkillCouncil", RequestProcessed = false, RequestSuccessful = false };

            if (councilTypeId > 0 && skillCouncilId > 0)
            {
                operationStatus = GetSkillCouncilDbService().RemoveSkillCouncil(councilTypeId, skillCouncilId);
            }

            return Ok(operationStatus);
        }

        #endregion CRUD Operations

        #region Private

        private ISkillCouncilDbService GetSkillCouncilDbService()
        {
            ISkillCouncilDbService service = new SkillCouncilDbService();
            return service;
        }

        #endregion Private
    }
}
