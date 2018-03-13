using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASSESSOR = AMS.API.DTO.Assessor;

namespace AMS.API.DTO.BatchAllocation
{
    public class BatchAllocationDetail
    {
        public Int64 BatchMasterId { get; set; }

        public string BatchId { get; set; }

        public string BatchName { get; set; }

        public Int64 BatchAllocationId { get; set; }

        public DateTime AssessmentDate { get; set; }

        public bool AssessmentTiming { get; set; }

        public ASSESSOR.Assessor Assessor { get; set; }
    }
}