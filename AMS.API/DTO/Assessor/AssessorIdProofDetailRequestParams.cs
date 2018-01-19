using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class AssessorIdProofDetailRequestParams
    {
        public Int64 Id { get; set; }

        public Int64 AssessorId { get; set; }

        public int IdProofTypeId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}