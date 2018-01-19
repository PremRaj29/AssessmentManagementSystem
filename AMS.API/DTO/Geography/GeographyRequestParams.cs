using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.API.DTO.Geography
{
    public class GeographyRequestParams
    {
        public int StateId { get; set; }

        public string StateName { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}