using AMS.API.DTO;
using AMS.API.DTO.Assessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    public interface IAssessorOtherDetailDbService
    {
        /// <summary>
        /// Return list of Assessor OtherDetails
        /// </summary>
        /// <returns></returns>
        OtherDetailsResponse GetOtherDetails(Int64 assessorId);

        /// <summary>
        /// Create/Add new Assessor OtherDetails
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddOtherDetail(AssessorOtherDetail data);

        /// <summary>
        /// /// Remove exisitng Assessor OtherDetails based on and @AssessorId
        /// </summary>
        /// <param name="assessorIdId"></param>
        /// <returns></returns>
        OperationStatus RemoveOtherDetail(Int64 assessorIdId);

        /// <summary>
        /// Modify Assessor OtherDetails data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateOtherDetail(AssessorOtherDetail data);
    }
}
