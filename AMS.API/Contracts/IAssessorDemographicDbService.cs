using AMS.API.DTO;
using AMS.API.DTO.Assessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    public interface IAssessorDemographicDbService
    {
        /// <summary>
        /// Return list of Assessors along with all other related data like Personal, JobRoles, PrefLocation etc
        /// </summary>
        /// <returns></returns>
        AssessorResponse GetAssessor(AssessorRequestParams request);

        /// <summary>
        /// Create/Add new Assessor of supplied @SkillCouncilId
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddAssessor(Assessor data);

        /// <summary>
        /// Remove exisitng Assessor based on @AssessorId
        /// </summary>
        /// <param name="assessorId"></param>
        /// <returns></returns>
        OperationStatus RemoveAssessor(Int64 assessorId);

        /// <summary>
        /// Modify Assessor data related in ALL categories like Personal, JobRoles, PrefLocation etc
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateAssessor(Assessor data);

        #region Custom Methods

        /// <summary>
        /// Return list of Assessors based on supplied Search-Parameters
        /// </summary>
        /// <returns></returns>
        AssessorResponse SearchAssessors(SearchAssessorRequestParams request);

        /*
        /// <summary>
        /// Modify Assessor "PerosnalDetails" only like FName, DOB, Marital Status etc
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateAssessorPerosnalDetails(AssessorPerosnalDetail data);

        /// <summary>
        /// Modify Assessor "CommunicationDetail" only like FName, DOB, Marital Status etc
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateAssessorCommunicationDetails(AssessorCommunicationDetail data);

        /// <summary>
        /// Modify Assessor "OtherDetail" only like OdigoStatus, BankName, Number etc
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateAssessorOtherDetails(AssessorOtherDetail data);

        /// <summary>
        /// Modify Assessor "IdProofs" only like Aadhar, DL, VoterId etc
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateAssessorIdProofs(AssessorIdProofDetail data);
        */

        #endregion
    }
}
