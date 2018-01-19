using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class AssessorPreferredLocation
    {
        public Int64 Id { get; set; }

        [JsonIgnore]
        public Int64 AssessorId { get; set; }

        public int StateId { get; set; }

        [Required]
        public int CityId { get; set; }

        public string CityName { get; set; }

        public string StateName { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsActive { get; set; }
    }
}