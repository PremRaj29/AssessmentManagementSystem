using AMS.API.DTO;
using AMS.API.DTO.BatchMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    public interface IBatchMasterDbService
    {
        /// <summary>
        /// Return list of BatchMaster available
        /// </summary>
        /// <returns></returns>
        BatchMasterResponse GetBatchMaster(BatchMasterRequestParams request);

        /// <summary>
        /// Create/Add new BatchMaster
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddBatchMaster(BatchMaster data);

        /// <summary>
        /// Remove exisitng BatchMaster based on and @BatchMasterId
        /// </summary>
        /// <param name="batchMasterId"></param>
        /// <returns></returns>
        OperationStatus RemoveBatchMaster(int batchMasterId);

        /// <summary>
        /// Modify BatchMaster data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateBatchMaster(BatchMaster data);

        /// <summary>
        /// Return list of BatchMaster details based on supplied Search-Parameters
        /// </summary>
        /// <returns></returns>
        BatchMasterResponse SearchBatchMaster(SearchBatchMasterRequestParams request);
    }
}
