using AMS.API.DTO;
using AMS.API.DTO.JobRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    public interface IJobRolesDbService
    {
        /// <summary>
        /// Return list of Job roles defined in sector skill council(SSC)
        /// </summary>
        /// <returns></returns>
        JobRoleResponse GetJobRoles(JobRoleRequestParams request);

        /// <summary>
        /// Create/Add new JobRole of supplied @SkillCouncilId
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddJobRoles(JobRole data);

        /// <summary>
        /// Remove exisitng JobRole based on @SkillCouncilId and @JobRoleId
        /// </summary>
        /// <param name="skillCouncilId"></param>
        /// <param name="jobRoleId"></param>
        /// <returns></returns>
        OperationStatus RemoveJobRoles(int skillCouncilId, int jobRoleId);

        /// <summary>
        /// Modify JobRole data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateJobRoles(JobRole data);

        #region Custom Methods

        /// <summary>
        /// Return list of Job roles based on supplied Search-Parameters
        /// </summary>
        /// <returns></returns>
        JobRoleResponse SearchJobRoles(SearchJobRolesRequestParams request);

        #endregion
    }
}
