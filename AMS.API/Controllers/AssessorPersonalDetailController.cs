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
    public class AssessorPersonalDetailController : BaseApiController
    {
        #region CRUD Operations

        //Get: AssessorPersonalDetail-1
        /// <summary>
        /// Get list of AssessorPersonalDetails based on AssessorId i.e. specific id or all
        /// </summary>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        [Route("AssessorPersonalDetail/{assessorId?}")]
        public IHttpActionResult Get(int assessorId)
        {
            return Ok(GetAssessorPersonalDetailDbService().GetPersonalDetails(assessorId));
        }

        //Post: AssessorPersonalDetail
        /// <summary>
        /// Create/Add new AssessorPersonalDetail
        /// </summary>
        /// <param name="assessor"></param>
        /// <returns></returns>
        [Route("AssessorPersonalDetail")]
        public IHttpActionResult Post(AssessorPersonalDetail assessor)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "POST", ServiceName = "AddAssessorPersonalDetail", RequestProcessed = false, RequestSuccessful = false };

            if (assessor != null)
            {
                if (assessor.AssessorId >0)
                {
                    operationStatus = GetAssessorPersonalDetailDbService().AddPersonalDetail(assessor);
                }
                //else
                //{
                //    operationStatus.Messages.Add(new Message() { DTOName = "AssessorPersonalDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use PUT method to update state of object." });
                //}
            }

            return Ok(operationStatus);
        }

        //Put: AssessorPersonalDetail
        /// <summary>
        /// Update existing AssessorPersonalDetail
        /// </summary>
        /// <param name="assessorPersonalDetail"></param>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        [Route("AssessorPersonalDetail/{assessorId}")]
        public IHttpActionResult Put(AssessorPersonalDetail assessorPersonalDetail, int assessorId = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "PUT", ServiceName = "UpdateAssessorPersonalDetail", RequestProcessed = false, RequestSuccessful = false };

            if (assessorPersonalDetail != null)
            {
                if (assessorId > 0)
                {
                    //Comment : Here set value of assessorId into DTO object and then call Update method
                    assessorPersonalDetail.AssessorId = assessorId;

                    operationStatus = GetAssessorPersonalDetailDbService().UpdatePersonalDetail(assessorPersonalDetail);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "AssessorPersonalDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use POST method to create object." });
                }
            }

            return Ok(operationStatus);
        }

        //Delete: AssessorPersonalDetail
        /// <summary>
        /// Remove existing AssessorPersonalDetail
        /// </summary>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        [Route("AssessorPersonalDetail/{assessorId}")]
        public IHttpActionResult Delete(int assessorId)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "DELETE", ServiceName = "RemoveAssessorPersonalDetail", RequestProcessed = false, RequestSuccessful = false };

            if (assessorId > 0)
            {
                operationStatus = GetAssessorPersonalDetailDbService().RemovePersonalDetail(assessorId);
            }

            return Ok(operationStatus);
        }

        #endregion CRUD Operations

        #region Private

        private IAssessorPersonalDetailDbService GetAssessorPersonalDetailDbService()
        {
            IAssessorPersonalDetailDbService service = new AssessorPersonalDetailDbService();
            return service;
        }

        #endregion Private
    }
}

