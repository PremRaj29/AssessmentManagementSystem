using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class SearchAssessorRequestParams : AssessorRequestParams
    {
        public string Name { get; set; }

        public char? Gender { get; set; }

        public string EmailId { get; set; }

        public string MobileNo { get; set; }

        public string WhatsAppNo { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }

        #region Additional Advance Params

        public int SkillCouncilTypeId { get; set; }

        public int SkillCouncilId { get; set; }

        public int JobRoleId { get; set; }

        public int IdProofTypeId { get; set; }

        public string IdProofValue { get; set; }

        public string AccountNumber { get; set; }

        #endregion
    }
}