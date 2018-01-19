using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Geography
{
    public class GeographyResponse
    {
        #region Constructor

        public GeographyResponse()
        {
            States = new List<State>();
            Cities = new List<City>();

            OperationStatus = new OperationStatus();
        }
        #endregion Constructor

        #region Class Properties

        public List<State> States { get; set; }

        public List<City> Cities { get; set; }

        public OperationStatus OperationStatus { get; set; }

        #endregion
    }
}