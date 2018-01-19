using AMS.API.DTO;
using AMS.API.DTO.Scheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    public interface ISchemeDbService
    {
        /// <summary>
        /// Return list of VTP's
        /// </summary>
        /// <returns></returns>
        SchemeResponse GetScheme(SchemeRequestParams request);

        /// <summary>
        /// Create/Add new Scheme
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddScheme(Scheme data);

        /// <summary>
        /// /// Remove exisitng Scheme based on and @SchemeId
        /// </summary>
        /// <param name="schemeId"></param>
        /// <returns></returns>
        OperationStatus RemoveScheme(int schemeId);

        /// <summary>
        /// Modify Scheme data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateScheme(Scheme data);
    }
}
