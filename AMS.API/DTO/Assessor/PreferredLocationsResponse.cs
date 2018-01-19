using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class PreferredLocationsResponse
    {
        #region Constructor

        public PreferredLocationsResponse()
        {
            PreferredLocations = new List<AssessorPreferredLocation>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<AssessorPreferredLocation> PreferredLocations { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}