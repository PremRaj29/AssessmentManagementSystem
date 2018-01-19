using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Scheme
{
    public class SchemeResponse
    {
        #region Constructor

        public SchemeResponse()
        {
            Scheme = new List<Scheme>();
            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<Scheme> Scheme { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}