using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.SkillCouncil
{
    public class SkillCouncil
    {
        public int Id { get; set; }

        public int CouncilTypeId { get; set; }

        public string CouncilType { get; set; }

        public string Code { get; set; }

        public string FullName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}