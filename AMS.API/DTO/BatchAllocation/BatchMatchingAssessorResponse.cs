using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASSESSOR = AMS.API.DTO.Assessor;

namespace AMS.API.DTO.BatchAllocation
{
    public class BatchMatchingAssessorResponse
    {
        #region Constructor

        public BatchMatchingAssessorResponse()
        {
            Assessors = new List<ASSESSOR.Assessor>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<ASSESSOR.Assessor> Assessors { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}