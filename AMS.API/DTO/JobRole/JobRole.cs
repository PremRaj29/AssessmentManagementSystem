using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.JobRole
{
    public class JobRole
    {
        public int Id { get; set; }

        public int SkillCouncilTypeId { get; set; }

        public int SkillCouncilId { get; set; }

        public string SkillCouncilCode { get; set; }

        public string SkillCouncilName { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; set; }

        public Int32 CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; }

        public Int32 ModifiedBy { get; set; }

        public bool IsActive { get; set; }
    }
}