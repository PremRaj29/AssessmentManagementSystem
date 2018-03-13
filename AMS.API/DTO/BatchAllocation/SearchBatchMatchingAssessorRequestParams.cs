using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.BatchAllocation
{
    public class SearchBatchMatchingAssessorRequestParams
    {
        public string BatchId { get; set; }

        public string BatchName { get; set; }

        public string AssessorName { get; set; }

        public DateTime AssessmentDate { get; set; }

        public bool AssessmentTiming { get; set; } //Batch Assessment timing like "AM or PM" only
    }
}