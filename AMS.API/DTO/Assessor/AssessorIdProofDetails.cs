using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class AssessorIdProofDetail
    {
        public Int64 Id { get; set; }

        [JsonIgnore]
        public Int64 AssessorId { get; set; }

        [Required]
        public int IdProofTypeId { get; set; }

        public string IdProofName { get; set; }

        [Required]
        [StringLength(30)]
        public string UniqueNumber { get; set; }

        [StringLength(200)]
        public string NameOnDocument { get; set; }

        [StringLength(50)]
        public string DocumentFileName { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        public Int32 CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; }

        public Int32 ModifiedBy { get; set; }

        public bool IsActive { get; set; }
    }
}