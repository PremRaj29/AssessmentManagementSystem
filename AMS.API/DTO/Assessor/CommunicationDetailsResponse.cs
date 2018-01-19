using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class CommunicationDetailsResponse
    {
        #region Constructor

        public CommunicationDetailsResponse()
        {
            CommunicationDetails = new List<AssessorCommunicationDetail>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<AssessorCommunicationDetail> CommunicationDetails { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}