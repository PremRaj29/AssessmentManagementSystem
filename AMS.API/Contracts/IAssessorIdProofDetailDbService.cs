using AMS.API.DTO;
using AMS.API.DTO.Assessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    public interface IAssessorIdProofDetailDbService
    {
        /// <summary>
        /// Return list of Assessor IdProofDetails
        /// </summary>
        /// <returns></returns>
        IdProofDetailsResponse GetIdProofDetails(AssessorIdProofDetailRequestParams request);

        /// <summary>
        /// Create/Add new Assessor IdProofDetails
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddIdProofDetail(AssessorIdProofDetail data);

        /// <summary>
        /// /// Remove exisitng Assessor IdProofDetails based on and @AssessorId
        /// </summary>
        /// <param name="assessorIdId"></param>
        /// <returns></returns>
        OperationStatus RemoveIdProofDetail(Int64 id, Int64 assessorId);

        /// <summary>
        /// Modify Assessor IdProofDetails data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateIdProofDetail(AssessorIdProofDetail data);
    }
}
