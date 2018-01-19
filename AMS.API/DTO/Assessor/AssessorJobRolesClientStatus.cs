using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class AssessorJobRolesClientStatus
    {

        [Required]
        public Int64 AssessorId { get; set; }

        [Required]
        public int JobRoleId { get; set; }
        
        [Required]
        public bool? ClientStatus { get; set; }

        [StringLength(250)]
        public string ClientRemarks { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        public Int32 CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; }

        public Int32 ModifiedBy { get; set; }

        public bool IsActive { get; set; }
    }
}