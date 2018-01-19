using AMS.API.DTO;
using AMS.API.DTO.Assessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    public interface IAssessorPreferredLocationDbService
    {
        /// <summary>
        /// Return list of Assessor PreferredLocations
        /// </summary>
        /// <returns></returns>
        PreferredLocationsResponse GetPreferredLocations(AssessorPreferredLocationRequestParams request);

        /// <summary>
        /// Create/Add new Assessor PreferredLocations
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddPreferredLocation(AssessorPreferredLocation data);

        /// <summary>
        /// /// Remove exisitng Assessor PreferredLocations based on and @AssessorId
        /// </summary>
        /// <param name="assessorIdId"></param>
        /// <returns></returns>
        OperationStatus RemovePreferredLocation(Int64 id, Int64 assessorId);

        /// <summary>
        /// Modify Assessor PreferredLocations data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdatePreferredLocation(AssessorPreferredLocation data);
    }
}
