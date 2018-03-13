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
    public class AssessorIdProofDetailController : BaseApiController
    {
        #region CRUD Operations

        //Get: AssessorIdProofDetail-1
        /// <summary>
        /// Get list of AssessorIdProofDetails based on AssessorIdProofDetailId i.e. specific id or all
        /// </summary>
        /// <param name="assessorIdProofDetailId"></param>
        /// <returns></returns>
        [Route("AssessorIdProofDetail/{assessorIdProofDetailId?}")]
        public IHttpActionResult Get(int assessorIdProofDetailId)
        {
            return Ok(GetAssessorIdProofDetailDbService().GetIdProofDetails(new AssessorIdProofDetailRequestParams() { Id = assessorIdProofDetailId }));
        }

        //Get: AssessorIdProofDetail-2
        /// <summary>
        /// Get list of AssessorIdProofDetail based on "Id, AssessorId, IdProofTypeId" search-type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assessorId"></param>
        /// <param name="jobRoleId"></param>
        /// <returns></returns>
        [Route("AssessorIdProofDetail/{id?}/{assessorId}/{jobRoleId}")]
        public IHttpActionResult Get(int assessorId, int IdProofTypeId, int id = 0)
        {
            return Ok(GetAssessorIdProofDetailDbService().GetIdProofDetails(new AssessorIdProofDetailRequestParams() { Id = id, AssessorId = assessorId, IdProofTypeId = IdProofTypeId }));
        }


        //Post: AssessorIdProofDetail
        /// <summary>
        /// Create/Add new AssessorIdProofDetail
        /// </summary>
        /// <param name="assessorIdProofDetail"></param>
        /// <returns></returns>
        [Route("AssessorIdProofDetail")]
        public IHttpActionResult Post(AssessorIdProofDetail assessorIdProofDetail)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "POST", ServiceName = "AddAssessorIdProofDetail", RequestProcessed = false, RequestSuccessful = false };

            if (assessorIdProofDetail != null)
            {
                if (assessorIdProofDetail.Id == 0)
                {
                    operationStatus = GetAssessorIdProofDetailDbService().AddIdProofDetail(assessorIdProofDetail);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "AssessorIdProofDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use PUT method to update state of object." });
                }
            }

            return Ok(operationStatus);
        }

        //Put: AssessorIdProofDetail
        /// <summary>
        /// Update existing AssessorIdProofDetail
        /// </summary>
        /// <param name="assessorIdProofDetail"></param>
        /// <param name="assessorIdProofDetailId"></param>
        /// <returns></returns>
        [Route("AssessorIdProofDetail/{assessorIdProofDetailId}")]
        public IHttpActionResult Put(AssessorIdProofDetail assessorIdProofDetail, int assessorIdProofDetailId = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "PUT", ServiceName = "UpdateAssessorIdProofDetail", RequestProcessed = false, RequestSuccessful = false };

            if (assessorIdProofDetail != null)
            {
                if (assessorIdProofDetailId > 0)
                {
                    //Comment : Here set value of assessorIdProofDetailId into DTO object and then call Update method
                    assessorIdProofDetail.Id = assessorIdProofDetailId;

                    operationStatus = GetAssessorIdProofDetailDbService().UpdateIdProofDetail(assessorIdProofDetail);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "AssessorIdProofDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use POST method to create object." });
                }
            }

            return Ok(operationStatus);
        }

        //Delete: AssessorIdProofDetail
        /// <summary>
        /// Remove existing AssessorIdProofDetail
        /// </summary>
        /// <param name="assessorId"></param>
        /// <param name="idProofTypeId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("AssessorIdProofDetail/{assessorId}/{idProofTypeId}/{id?}")]
        public IHttpActionResult Delete(int assessorId, int idProofTypeId, int id = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "DELETE", ServiceName = "RemoveAssessorIdProofDetail", RequestProcessed = false, RequestSuccessful = false };

            if (assessorId > 0)
            {
                operationStatus = GetAssessorIdProofDetailDbService().RemoveIdProofDetail(assessorId, idProofTypeId, id);
            }

            return Ok(operationStatus);
        }

        #endregion CRUD Operations

        #region Private

        private IAssessorIdProofDetailDbService GetAssessorIdProofDetailDbService()
        {
            IAssessorIdProofDetailDbService service = new AssessorIdProofDetailDbService();
            return service;
        }

        #endregion Private
    }
}
