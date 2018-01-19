using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.JobRole
{
    public class SearchJobRolesRequestParams
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int SkillCouncilTypeId { get; set; }

        public int SkillCouncilId { get; set; }
    }
}