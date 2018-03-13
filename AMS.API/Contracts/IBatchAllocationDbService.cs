using AMS.API.DTO;
using AMS.API.DTO.BatchAllocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    public interface IBatchAllocationDbService
    {
        /// <summary>
        /// Return list of matching "Assessor"(Which is Available on supplied date & time) for given BatchMaster Id/Name
        /// </summary>
        /// <returns></returns>
        BatchMatchingAssessorResponse GetBatchMatchingAssessors(SearchBatchMatchingAssessorRequestParams request);

        /// <summary>
        /// Create/Add new BatchAllocation of supplied BatchId & AssessorId and params
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddBatchAllocation(BatchAllocation data);

        /// <summary>
        /// Remove existing allocated/mapped association between Batch & Assessor
        /// </summary>
        /// <param name="allocationId"></param>
        /// <param name="batchMasterId"></param>
        /// <param name="asessorId"></param>
        /// <returns></returns>
        OperationStatus RemoveBatchAllocation(int allocationId, int batchMasterId, int asessorId);
    }
}
