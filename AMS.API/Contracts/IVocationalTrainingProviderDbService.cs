using AMS.API.DTO;
using AMS.API.DTO.VTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    public interface IVocationalTrainingProviderDbService
    {
        /// <summary>
        /// Return list of VTP's
        /// </summary>
        /// <returns></returns>
        VocationalTrainingProviderResponse GetVocationalTrainingProvider(VocationalTrainingProviderRequestParams request);

        /// <summary>
        /// Create/Add new VocationalTrainingProvider
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddVocationalTrainingProvider(VocationalTrainingProvider data);

        /// <summary>
        /// /// Remove exisitng VocationalTrainingProvider based on and @VocationalTrainingProviderId
        /// </summary>
        /// <param name="vocationalTrainingProviderId"></param>
        /// <returns></returns>
        OperationStatus RemoveVocationalTrainingProvider(int vocationalTrainingProviderId);

        /// <summary>
        /// Modify VocationalTrainingProvider data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateVocationalTrainingProvider(VocationalTrainingProvider data);
    }
}
