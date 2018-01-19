using AMS.API.DTO;
using AMS.API.DTO.Assessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    public interface IAssessorCommunicationDetailDbService
    {
        /// <summary>
        /// Return list of Assessor CommunicationDetails
        /// </summary>
        /// <returns></returns>
        CommunicationDetailsResponse GetCommunicationDetails(Int64 assessorId);

        /// <summary>
        /// Create/Add new Assessor CommunicationDetail
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddCommunicationDetail(AssessorCommunicationDetail data);

        /// <summary>
        /// /// Remove exisitng Assessor CommunicationDetail based on and @AssessorId
        /// </summary>
        /// <param name="assessorIdId"></param>
        /// <returns></returns>
        OperationStatus RemoveCommunicationDetail(Int64 assessorIdId);

        /// <summary>
        /// Modify Assessor CommunicationDetail data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateCommunicationDetail(AssessorCommunicationDetail data);
    }
}
