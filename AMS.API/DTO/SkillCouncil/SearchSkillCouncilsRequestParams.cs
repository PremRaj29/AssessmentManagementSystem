using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.SkillCouncil
{
    public class SearchSkillCouncilsRequestParams
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int SkillCouncilTypeId { get; set; }
    }
}