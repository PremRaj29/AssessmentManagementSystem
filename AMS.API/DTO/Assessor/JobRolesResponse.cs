using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class JobRolesResponse
    {
        #region Constructor

        public JobRolesResponse()
        {
            JobRoles = new List<AssessorJobRole>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<AssessorJobRole> JobRoles { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}