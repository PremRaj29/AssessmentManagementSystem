using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class AssessorOtherDetail
    {
        public Int64 AssessorId { get; set; }

        [StringLength(20)]
        public string OdigoOkayStatus { get; set; }

        [StringLength(250)]
        public string BankName { get; set; }

        [StringLength(20)]
        public string AccountNumber { get; set; }

        [StringLength(20)]
        public string IFSC_Code { get; set; }

        [StringLength(500)]
        public string BankAddress { get; set; }

        public string HighestQualificationName { get; set; }

        public int HighestQualificationId { get; set; }

        [StringLength(500)]
        public string Qualifications { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int ModifiedBy { get; set; }

        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }
    }
}