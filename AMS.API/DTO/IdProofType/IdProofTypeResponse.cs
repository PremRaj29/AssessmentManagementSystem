using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.IdProofType
{
    public class IdProofTypeResponse
    {
        #region Constructor

        public IdProofTypeResponse()
        {
            IdProofTypes = new List<IdProofType>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<IdProofType> IdProofTypes { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}