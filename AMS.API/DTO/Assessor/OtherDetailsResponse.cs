using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class OtherDetailsResponse
    {
        #region Constructor

        public OtherDetailsResponse()
        {
            OtherDetails = new List<AssessorOtherDetail>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<AssessorOtherDetail> OtherDetails { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}