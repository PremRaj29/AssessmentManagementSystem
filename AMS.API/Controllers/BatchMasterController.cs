using AMS.API.Contracts;
using AMS.API.Core;
using AMS.API.DTO;
using AMS.API.DTO.BatchMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMS.API.Controllers
{
    [RoutePrefix("api")]
    public class BatchMasterController : BaseApiController
    {
        #region CRUD Operations

        //Get: BatchMaster-1
        /// <summary>
        /// Get list of BatchMaster based on BatchMasterId i.e. specific id or all
        /// </summary>
        /// <param name="batchMasterId"></param>
        /// <returns></returns>
        [Route("BatchMaster/{batchMasterId?}")]
        public IHttpActionResult Get(int batchMasterId)
        {
            return Ok(GetBatchMasterDbService().GetBatchMaster(new BatchMasterRequestParams() { Id = batchMasterId }));
        }

        //Get: BatchMaster-2
        /// <summary>
        /// Get list of BatchMaster based on "BatchId or BatchName" search-type
        /// </summary>
        /// <param name="batchId"></param>
        /// <param name="batchName"></param>
        /// <returns></returns>
        [Route("BatchMaster/{batchId?}/{batchName?}")]
        public IHttpActionResult Get(string batchId = null, string batchName = null)
        {
            return Ok(GetBatchMasterDbService().GetBatchMaster(new BatchMasterRequestParams() { BatchId = batchId,BatchName = batchName }));
        }

        //Get: SearchJobRoles
        [Route("BatchMaster/Search")]
        public IHttpActionResult GetSearchedBatchMaster([FromUri]SearchBatchMasterRequestParams searchParams)
        {
            if (searchParams == null)
            {
                searchParams = new SearchBatchMasterRequestParams();
            }

            return Ok(GetBatchMasterDbService().SearchBatchMaster(searchParams));
        }


        //Post: BatchMaster
        /// <summary>
        /// Create/Add new BatchMaster
        /// </summary>
        /// <param name="batchMaster"></param>
        /// <returns></returns>
        [Route("BatchMaster")]
        public IHttpActionResult Post(BatchMaster batchMaster)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "POST", ServiceName = "AddBatchMaster", RequestProcessed = false, RequestSuccessful = false };

            if (batchMaster != null)
            {
                if (batchMaster.Id == 0)
                {
                    operationStatus = GetBatchMasterDbService().AddBatchMaster(batchMaster);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "BatchMaster", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use PUT method to update state of object." });
                }
            }

            return Ok(operationStatus);
        }

        //Put: BatchMaster
        /// <summary>
        /// Update existing BatchMaster
        /// </summary>
        /// <param name="batchMaster"></param>
        /// <param name="batchMasterId"></param>
        /// <returns></returns>
        [Route("BatchMaster/{batchMasterId}")]
        public IHttpActionResult Put(BatchMaster batchMaster, int batchMasterId = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "PUT", ServiceName = "UpdateBatchMaster", RequestProcessed = false, RequestSuccessful = false };

            if (batchMaster != null)
            {
                if (batchMasterId > 0)
                {
                    //Comment : Here set value of batchMasterId into DTO object and then call Update method
                    batchMaster.Id = batchMasterId;

                    operationStatus = GetBatchMasterDbService().UpdateBatchMaster(batchMaster);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "BatchMaster", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use POST method to create object." });
                }
            }

            return Ok(operationStatus);
        }

        //Delete: BatchMaster
        /// <summary>
        /// Remove existing BatchMaster
        /// </summary>
        /// <param name="batchMasterId"></param>
        /// <returns></returns>
        [Route("BatchMaster/{batchMasterId}")]
        public IHttpActionResult Delete(int batchMasterId = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "DELETE", ServiceName = "RemoveBatchMaster", RequestProcessed = false, RequestSuccessful = false };

            if (batchMasterId > 0)
            {
                operationStatus = GetBatchMasterDbService().RemoveBatchMaster(batchMasterId);
            }

            return Ok(operationStatus);
        }

        #endregion CRUD Operations

        #region Private

        private IBatchMasterDbService GetBatchMasterDbService()
        {
            IBatchMasterDbService service = new BatchMasterDbService();
            return service;
        }

        #endregion Private
    }
}
