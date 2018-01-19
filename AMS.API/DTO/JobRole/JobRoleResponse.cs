using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.JobRole
{
    public class JobRoleResponse
    {
        #region Constructor

        public JobRoleResponse()
        {
            JobRoles = new List<JobRole>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<JobRole> JobRoles { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}