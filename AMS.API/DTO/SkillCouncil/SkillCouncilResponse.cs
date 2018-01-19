using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.SkillCouncil
{
    public class SkillCouncilResponse
    {
        #region Constructor

        public SkillCouncilResponse()
        {
            SkillCouncil = new List<SkillCouncil>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<SkillCouncil> SkillCouncil { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}