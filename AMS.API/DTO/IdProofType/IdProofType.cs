using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.IdProofType
{
    public class IdProofType
    {
        public int Id { get; set; }

        public string ProofName { get; set; }

        public bool IsActive { get; set; }
    }
}