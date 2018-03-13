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
    public class AssessorCommunicationDetailController : BaseApiController
    {
        #region CRUD Operations

        //Get: AssessorCommunicationDetail-1
        /// <summary>
        /// Get list of AssessorCommunicationDetails based on AssessorId i.e. specific id or all
        /// </summary>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        [Route("AssessorCommunicationDetail/{assessorId?}")]
        public IHttpActionResult Get(int assessorId)
        {
            return Ok(GetAssessorCommunicationDetailDbService().GetCommunicationDetails(assessorId));
        }

        //Post: AssessorCommunicationDetail
        /// <summary>
        /// Create/Add new AssessorCommunicationDetail
        /// </summary>
        /// <param name="assessor"></param>
        /// <returns></returns>
        [Route("AssessorCommunicationDetail")]
        public IHttpActionResult Post(AssessorCommunicationDetail assessor)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "POST", ServiceName = "AddAssessorCommunicationDetail", RequestProcessed = false, RequestSuccessful = false };

            if (assessor != null)
            {
                if (assessor.AssessorId > 0)
                {
                    operationStatus = GetAssessorCommunicationDetailDbService().AddCommunicationDetail(assessor);
                }
                //else
                //{
                //    operationStatus.Messages.Add(new Message() { DTOName = "AssessorCommunicationDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use PUT method to update state of object." });
                //}
            }

            return Ok(operationStatus);
        }

        //Put: AssessorCommunicationDetail
        /// <summary>
        /// Update existing AssessorCommunicationDetail
        /// </summary>
        /// <param name="assessorCommunicationDetail"></param>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        [Route("AssessorCommunicationDetail/{assessorId}")]
        public IHttpActionResult Put(AssessorCommunicationDetail assessorCommunicationDetail, int assessorId)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "PUT", ServiceName = "UpdateAssessorCommunicationDetail", RequestProcessed = false, RequestSuccessful = false };

            if (assessorCommunicationDetail != null)
            {
                if (assessorId > 0)
                {
                    //Comment : Here set value of assessorId into DTO object and then call Update method
                    assessorCommunicationDetail.AssessorId = assessorId;

                    operationStatus = GetAssessorCommunicationDetailDbService().UpdateCommunicationDetail(assessorCommunicationDetail);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "AssessorCommunicationDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use POST method to create object." });
                }
            }

            return Ok(operationStatus);
        }

        //Delete: AssessorCommunicationDetail
        /// <summary>
        /// Remove existing AssessorCommunicationDetail
        /// </summary>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        [Route("AssessorCommunicationDetail/{assessorId}")]
        public IHttpActionResult Delete(int assessorId)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "DELETE", ServiceName = "RemoveAssessorCommunicationDetail", RequestProcessed = false, RequestSuccessful = false };

            if (assessorId > 0)
            {
                operationStatus = GetAssessorCommunicationDetailDbService().RemoveCommunicationDetail(assessorId);
            }

            return Ok(operationStatus);
        }

        #endregion CRUD Operations

        #region Private

        private IAssessorCommunicationDetailDbService GetAssessorCommunicationDetailDbService()
        {
            IAssessorCommunicationDetailDbService service = new AssessorCommunicationDetailDbService();
            return service;
        }

        #endregion Private
    }
}

