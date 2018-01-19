using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class AssessorJobRoleRequestParams
    {
        public Int64 Id { get; set; }

        public Int64 AssessorId { get; set; }

        public int JobRoleId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}