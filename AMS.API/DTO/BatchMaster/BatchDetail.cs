using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.BatchMaster
{
    public class BatchDetail
    {
        [JsonIgnore]
        public Int64 BatchMasterId { get; set; }

        [Required]
        public int SchemeId { get; set; }

        public string SchemeName { get; set; }

        public int SkillCouncilTypeId { get; set; }

        public int SkillCouncilId { get; set; }

        [Required]
        public int JobRoleId { get; set; }

        public string JobRoleName { get; set; }

        public int StateId { get; set; }        

        [Required]
        public int CityId { get; set; }

        public string CityName { get; set; }

        public string StateName { get; set; }

        public string District { get; set; }

        public int TotalCandidates { get; set; }

        [Required]
        public int VTP_Id { get; set; }

        public string VTP_Name { get; set; }

        public string VTP_SPOC_Name { get; set; }

        public string VTP_SPOC_Email { get; set; }

        public string VTP_SPOC_Mobile { get; set; }

        public string VTP_SPOC_Mobile2 { get; set; }

        public string VTP_SPOC_AlternativeNo { get; set; }

        public string VTP_Address { get; set; }

        public string Centre_SPOC_Name { get; set; }

        public string Centre_SPOC_Email { get; set; }

        public string Centre_SPOC_Mobile { get; set; }
    }
}