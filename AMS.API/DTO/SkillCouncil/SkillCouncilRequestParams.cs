using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.SkillCouncil
{
    public class SkillCouncilRequestParams
    {
        public int SkillCouncilId { get; set; }

        public int CouncilTypeId { get; set; }

        public string Code { get; set; }

        public bool IsActive { get; set; } = true;
    }
}