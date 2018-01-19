using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.VTP
{
    public class VocationalTrainingProviderResponse
    {
        #region Constructor

        public VocationalTrainingProviderResponse()
        {
            VocationalTrainingProvider = new List<VocationalTrainingProvider>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<VocationalTrainingProvider> VocationalTrainingProvider { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}