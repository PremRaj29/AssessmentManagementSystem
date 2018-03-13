using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class AssessorCommunicationDetail
    {
        public Int64 AssessorId { get; set; }

        public int? StateId { get; set; }

        [Required]
        public int? CityId { get; set; }

        public string CityName { get; set; }

        public string StateName { get; set; }

        [StringLength(100)]
        public string OtherLocalityName { get; set; }

        [Required]
        [StringLength(150)]
        public string EmailId { get; set; }

        [Required]
        [StringLength(10)]
        public string MobileNo { get; set; }

        public bool? WhatsAppOnPrimaryNo { get; set; }

        [StringLength(10)]
        public string WhatsAppNo { get; set; }

        [StringLength(150)]
        public string SecondaryEmailId { get; set; }

        [StringLength(10)]
        public string SecondaryMobileNo { get; set; }

        [StringLength(15)]
        public string LandlineNo { get; set; }

        [StringLength(10)]
        public string EmergancyContactNo1 { get; set; }

        [StringLength(10)]
        public string EmergancyContactNo2 { get; set; }

        [Required]
        [StringLength(50)]
        public string CommAddressLine1 { get; set; }

        [StringLength(50)]
        public string CommAddressLine2 { get; set; }

        [StringLength(50)]
        public string CommAddressLine3 { get; set; }

        [StringLength(5)]
        public string CommAddressPinCode { get; set; }

        public bool? HasSameAsCommAddress { get; set; }

        [StringLength(50)]
        public string PermanentAddressLine1 { get; set; }

        [StringLength(50)]
        public string PermanentAddressLine2 { get; set; }

        [StringLength(50)]
        public string PermanentAddressLine3 { get; set; }

        [StringLength(5)]
        public string PermanentAddressPinCode { get; set; }
    }
}