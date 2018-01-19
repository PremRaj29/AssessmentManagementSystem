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
