using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class PersonalDetailsResponse
    {
        #region Constructor

        public PersonalDetailsResponse()
        {
            PerosnalDetails = new List<AssessorPersonalDetail>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<AssessorPersonalDetail> PerosnalDetails { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}