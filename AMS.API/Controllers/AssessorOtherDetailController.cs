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
    public class AssessorOtherDetailController : BaseApiController
    {
        #region CRUD Operations

        //Get: AssessorOtherDetail-1
        /// <summary>
        /// Get list of AssessorOtherDetails based on AssessorId i.e. specific id or all
        /// </summary>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        [Route("AssessorOtherDetail/{assessorId?}")]
        public IHttpActionResult Get(int assessorId)
        {
            return Ok(GetAssessorOtherDetailDbService().GetOtherDetails(assessorId));
        }

        //Post: AssessorOtherDetail
        /// <summary>
        /// Create/Add new AssessorOtherDetail
        /// </summary>
        /// <param name="assessor"></param>
        /// <returns></returns>
        [Route("AssessorOtherDetail")]
        public IHttpActionResult Post(AssessorOtherDetail assessor)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "POST", ServiceName = "AddAssessorOtherDetail", RequestProcessed = false, RequestSuccessful = false };

            if (assessor != null)
            {
                if (assessor.AssessorId > 0)
                {
                    operationStatus = GetAssessorOtherDetailDbService().AddOtherDetail(assessor);
                }
                //else
                //{
                //    operationStatus.Messages.Add(new Message() { DTOName = "AssessorOtherDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use PUT method to update state of object." });
                //}
            }

            return Ok(operationStatus);
        }

        //Put: AssessorOtherDetail
        /// <summary>
        /// Update existing AssessorOtherDetail
        /// </summary>
        /// <param name="assessorOtherDetail"></param>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        [Route("AssessorOtherDetail/{assessorId}")]
        public IHttpActionResult Put(AssessorOtherDetail assessorOtherDetail, int assessorId)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "PUT", ServiceName = "UpdateAssessorOtherDetail", RequestProcessed = false, RequestSuccessful = false };

            if (assessorOtherDetail != null)
            {
                if (assessorId > 0)
                {
                    //Comment : Here set value of assessorId into DTO object and then call Update method
                    assessorOtherDetail.AssessorId = assessorId;

                    operationStatus = GetAssessorOtherDetailDbService().UpdateOtherDetail(assessorOtherDetail);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "AssessorOtherDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use POST method to create object." });
                }
            }

            return Ok(operationStatus);
        }

        //Delete: AssessorOtherDetail
        /// <summary>
        /// Remove existing AssessorOtherDetail
        /// </summary>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        [Route("AssessorOtherDetail/{assessorId}")]
        public IHttpActionResult Delete(int assessorId)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "DELETE", ServiceName = "RemoveAssessorOtherDetail", RequestProcessed = false, RequestSuccessful = false };

            if (assessorId > 0)
            {
                operationStatus = GetAssessorOtherDetailDbService().RemoveOtherDetail(assessorId);
            }

            return Ok(operationStatus);
        }

        #endregion CRUD Operations

        #region Private

        private IAssessorOtherDetailDbService GetAssessorOtherDetailDbService()
        {
            IAssessorOtherDetailDbService service = new AssessorOtherDetailDbService();
            return service;
        }

        #endregion Private
    }
}

