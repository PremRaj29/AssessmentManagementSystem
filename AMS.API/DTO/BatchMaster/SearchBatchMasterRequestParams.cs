using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.BatchMaster
{
    public class SearchBatchMasterRequestParams
    {
        public string BatchId { get; set; }

        public string BatchName { get; set; }

        #region All other details

        public int SchemeId { get; set; }

        //public string SchemeName { get; set; }

        public int JobRoleId { get; set; }

        public int CityId { get; set; }

        public int VTP_Id { get; set; }

        public int TotalCandidates { get; set; }

        #endregion
    }
}