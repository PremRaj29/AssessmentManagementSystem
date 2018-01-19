using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.BatchAllocation
{
    public class BatchAllocation
    {
        public Int64 Id { get; set; }

        [Required]
        public Int64 BatchMasterId { get; set; }

        public string BatchId { get; set; }

        public string BatchName { get; set; }

        [Required]
        public int AssessorId { get; set; }

        public string AssessorName { get; set; }

        public DateTime AssessmentDate { get; set; }

        public bool Timing { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        public Int32 CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; }

        public Int32 ModifiedBy { get; set; }

        public bool IsActive { get; set; }
    }
}