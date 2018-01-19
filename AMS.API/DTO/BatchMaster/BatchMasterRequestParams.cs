using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.BatchMaster
{
    public class BatchMasterRequestParams
    {
        public int Id { get; set; }

        public string BatchId { get; set; }

        public string BatchName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}