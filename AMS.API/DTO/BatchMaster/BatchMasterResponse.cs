using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.BatchMaster
{
    public class BatchMasterResponse
    {
        #region Constructor

        public BatchMasterResponse()
        {
            BatchMaster = new List<BatchMaster>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<BatchMaster> BatchMaster { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}