using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.VTP
{
    public class VocationalTrainingProviderRequestParams
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; } = true;
    }
}