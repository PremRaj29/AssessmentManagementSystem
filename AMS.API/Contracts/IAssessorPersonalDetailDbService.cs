using AMS.API.DTO;
using AMS.API.DTO.Assessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    public interface IAssessorPersonalDetailDbService
    {
        /// <summary>
        /// Return list of Assessor PersonalDetails
        /// </summary>
        /// <returns></returns>
        PersonalDetailsResponse GetPersonalDetails(Int64 assessorId);

        /// <summary>
        /// Create/Add new Assessor PersonalDetails
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddPersonalDetail(AssessorPersonalDetail data);

        /// <summary>
        /// /// Remove exisitng Assessor PersonalDetails based on and @AssessorId
        /// </summary>
        /// <param name="assessorIdId"></param>
        /// <returns></returns>
        OperationStatus RemovePersonalDetail(Int64 assessorIdId);

        /// <summary>
        /// Modify Assessor PersonalDetails data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdatePersonalDetail(AssessorPersonalDetail data);
    }
}
