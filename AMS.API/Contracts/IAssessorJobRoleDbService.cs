using AMS.API.DTO;
using AMS.API.DTO.Assessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    public interface IAssessorJobRoleDbService
    {
        /// <summary>
        /// Return list of Assessor JobRoles
        /// </summary>
        /// <returns></returns>
        JobRolesResponse GetJobRoles(AssessorJobRoleRequestParams request);

        /// <summary>
        /// Create/Add new Assessor JobRoles
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddJobRole(AssessorJobRole data);

        /// <summary>
        /// /// Remove exisitng Assessor JobRoles based on and @AssessorId
        /// </summary>
        /// <param name="assessorIdId"></param>
        /// <returns></returns>
        OperationStatus RemoveJobRole(Int64 id, Int64 assessorId);

        /// <summary>
        /// Modify Assessor JobRoles data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateJobRole(AssessorJobRole data);
    }
}
