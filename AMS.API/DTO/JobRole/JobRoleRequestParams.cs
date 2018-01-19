using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.JobRole
{
    public class JobRoleRequestParams
    {
        public int JobRoleId { get; set; }

        public int SkillCouncilId { get; set; }

        public string Code { get; set; }

        public bool IsActive { get; set; } = true;
    }
}