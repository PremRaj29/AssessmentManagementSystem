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
        /// Create/Add new BatchAllocation of supplied BatchId & AssessorId and params
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddBatchAllocation(BatchAllocation data);
    }
}
