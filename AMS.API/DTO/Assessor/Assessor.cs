using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class Assessor
    {
        public Int64 Id { get; set; }

        [Required]
        [StringLength(30)]
        public string IRIS_Id { get; set; }

        [StringLength(20)]
        public string SSC_Id { get; set; }

        [StringLength(20)]
        public string NSDC_Id { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        public Int32 CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; }

        public Int32 ModifiedBy { get; set; }

        public bool IsActive { get; set; }

        #region All other Assessors related details

        /// <summary>
        /// Assessor basic personal details e.g. FName, DOB, Marital Status etc
        /// </summary>
        public AssessorPersonalDetail PerosnalDetail { get; set; }

        /// <summary>
        /// Assessor basic personal details e.g. FName, DOB, Marital Status etc
        /// </summary>
        public AssessorCommunicationDetail CommunicationDetail { get; set; }

        /// <summary>
        /// Assessor all other details like OdigoStatus, BankName, Number etc
        /// </summary>
        public AssessorOtherDetail OtherDetail { get; set; }

        /// <summary>
        /// Assessor basic unique identity proofs e.g. Aadhar, DL, VoterId etc
        /// </summary>
        public List<AssessorIdProofDetail> IdProofs { get; set; }

        /// <summary>
        /// Assessor professional preferred Job-Roles list
        /// </summary>
        public List<AssessorJobRole> JobRoles { get; set; }

        /// <summary>
        /// Assessor preferred Job-Locations(City) list
        /// </summary>
        public List<AssessorPreferredLocation> PreferredLocations { get; set; }

        #endregion
    }
}