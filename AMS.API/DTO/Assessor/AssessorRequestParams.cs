using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class AssessorRequestParams
    {
        public Int64 AssessorId { get; set; }

        public string IRIS_Id { get; set; }

        public string SSC_Id { get; set; }

        public string NSDC_Id { get; set; }        

        public bool IsActive { get; set; } = true;
    }
}