using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Assessor
{
    public class AssessorResponse
    {
        #region Constructor

        public AssessorResponse()
        {
            Assessor = new List<Assessor>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<Assessor> Assessor { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}