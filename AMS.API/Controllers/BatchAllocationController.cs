using AMS.API.Contracts;
using AMS.API.Core;
using AMS.API.DTO;
using AMS.API.DTO.BatchAllocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMS.API.Controllers
{
    [RoutePrefix("api")]
    public class BatchAllocationController : BaseApiController
    {
        #region CRUD Operations

        /// <summary>
        /// Method will return list of matching Assessors ("Available") with BatchMaster requirement like "JobRoleId, LocationId"
        /// </summary>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        //Get: BatchAllocation
        [Route("BatchAllocation/SearchAssessor")]
        [HttpPost]
        public IHttpActionResult SearchBatchMatchingAssessors(SearchBatchMatchingAssessorRequestParams searchParams)
        {
            if (searchParams == null)
            {
                searchParams = new SearchBatchMatchingAssessorRequestParams();
            }

            return Ok(GetBatchAllocationDbService().GetBatchMatchingAssessors(searchParams));
        }

        //Post: BatchAllocation
        /// <summary>
        /// Create/Add new BatchAllocation based on supplied BatchMasterId & AssessorId
        /// </summary>
        /// <param name="batchAllocation"></param>
        /// <returns></returns>
        /// <returns></returns>
        [Route("BatchAllocation")]
        public IHttpActionResult Post(BatchAllocation batchAllocation)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "POST", ServiceName = "AddBatchAllocation", RequestProcessed = false, RequestSuccessful = false };

            if (batchAllocation != null)
            {
                if (batchAllocation.Id == 0)
                {
                    operationStatus = GetBatchAllocationDbService().AddBatchAllocation(batchAllocation);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "BatchAllocation", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use PUT method to update state of object." });
                }
            }

            return Ok(operationStatus);
        }

        //Delete: BatchAllocation
        /// <summary>
        /// Remove existing BatchAllocation where supplied Assessor is mapped/allocated on Batch
        /// </summary>
        /// <param name="councilTypeId"></param>
        /// <param name="skillCouncilId"></param>
        /// <returns></returns>
        [Route("BatchAllocation/{allocationId?}/BatchMaster/{batchMasterId}/Assessor/{asessorId}")]
        public IHttpActionResult Delete(int batchMasterId, int asessorId, int allocationId = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "DELETE", ServiceName = "RemoveAssessorBatchMapping", RequestProcessed = false, RequestSuccessful = false };

            if (allocationId >0 || (batchMasterId > 0 && asessorId > 0))
            {
                operationStatus = GetBatchAllocationDbService().RemoveBatchAllocation(allocationId,batchMasterId, asessorId);
            }

            return Ok(operationStatus);
        }

        #endregion CRUD Operations

        #region Private

        private IBatchAllocationDbService GetBatchAllocationDbService()
        {
            IBatchAllocationDbService service = new BatchAllocationDbService();
            return service;
        }

        #endregion Private
    }
}
