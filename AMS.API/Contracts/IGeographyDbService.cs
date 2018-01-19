using AMS.API.DTO;
using AMS.API.DTO.Geography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    interface IGeographyDbService
    {
        /// <summary>
        /// Return list of Geography data like State, City
        /// </summary>
        /// <returns></returns>
        GeographyResponse GetGeographies(GeographyRequestParams request);

        /// <summary>
        /// Return list of States or specific state when state-id is supplied
        /// </summary>
        /// <returns></returns>
        GeographyResponse GetStates(int stateId);

        /// <summary>
        /// Return list of Cities under state-id or specific City when city-id supplied
        /// </summary>
        /// <returns></returns>
        GeographyResponse GetCities(int stateId, int cityId);
    }
}
