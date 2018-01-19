using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class IdProofDetailsResponse
    {
        #region Constructor

        public IdProofDetailsResponse()
        {
            IdProofDetails = new List<AssessorIdProofDetail>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<AssessorIdProofDetail> IdProofDetails { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}