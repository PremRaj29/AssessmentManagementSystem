using AMS.API.Contracts;
using AMS.API.Core;
using AMS.API.DTO;
using AMS.API.DTO.VTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMS.API.Controllers
{
    [RoutePrefix("api")]
    public class VocationalTrainingProviderController : BaseApiController
    {
        #region CRUD Operations

        //Get: VocationalTrainingProvider
        /// <summary>
        /// Get list of VocationalTrainingProvider based on id i.e. specific or all
        /// </summary>
        /// <param name="vocationalTrainingProviderId"></param>
        /// <returns></returns>
        [Route("VocationalTrainingProvider/{vocationalTrainingProviderId?}")]
        public IHttpActionResult Get(int vocationalTrainingProviderId = 0)
        {
            return Ok(GetVocationalTrainingProviderDbService().GetVocationalTrainingProvider(new VocationalTrainingProviderRequestParams() { Id = vocationalTrainingProviderId }));
        }

        //Post: VocationalTrainingProvider
        /// <summary>
        /// Create/Add new VocationalTrainingProvider
        /// </summary>
        /// <param name="vocationalTrainingProvider"></param>
        /// <returns></returns>
        [Route("VocationalTrainingProvider")]
        public IHttpActionResult Post(VocationalTrainingProvider vocationalTrainingProvider)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "POST", ServiceName = "AddVocationalTrainingProvider", RequestProcessed = false, RequestSuccessful = false };

            if (vocationalTrainingProvider != null)
            {
                if (vocationalTrainingProvider.Id == 0)
                {
                    operationStatus = GetVocationalTrainingProviderDbService().AddVocationalTrainingProvider(vocationalTrainingProvider);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "VocationalTrainingProvider", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use PUT method to update state of object." });
                }
            }

            return Ok(operationStatus);
        }

        //Put: VocationalTrainingProvider
        /// <summary>
        /// Update existing VocationalTrainingProvider
        /// </summary>
        /// <param name="vocationalTrainingProvider"></param>
        /// <param name="vocationalTrainingProviderId"></param>
        /// <returns></returns>
        [Route("VocationalTrainingProvider/{vocationalTrainingProviderId}")]
        public IHttpActionResult Put(VocationalTrainingProvider vocationalTrainingProvider, int vocationalTrainingProviderId = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "PUT", ServiceName = "UpdateVocationalTrainingProvider", RequestProcessed = false, RequestSuccessful = false };

            if (vocationalTrainingProvider != null)
            {
                if (vocationalTrainingProviderId > 0)
                {
                    //Comment : Here set value of vocationalTrainingProviderId into DTO object and then call Update method
                    vocationalTrainingProvider.Id = vocationalTrainingProviderId;

                    operationStatus = GetVocationalTrainingProviderDbService().UpdateVocationalTrainingProvider(vocationalTrainingProvider);
                }
                else
                {
                    operationStatus.Messages.Add(new Message() { DTOName = "VocationalTrainingProvider", DTOProperty = "", MessageType = MessageType.SystemError, Text = "Please  use POST method to create object." });
                }
            }

            return Ok(operationStatus);
        }

        //Delete: VocationalTrainingProvider
        /// <summary>
        /// Remove existing VocationalTrainingProvider
        /// </summary>
        /// <param name="vocationalTrainingProviderId"></param>
        /// <returns></returns>
        [Route("VocationalTrainingProvider/{vocationalTrainingProviderId}")]
        public IHttpActionResult Delete(int vocationalTrainingProviderId = 0)
        {
            OperationStatus operationStatus = new OperationStatus() { ServiceMethod = "DELETE", ServiceName = "RemoveVocationalTrainingProvider", RequestProcessed = false, RequestSuccessful = false };

            if (vocationalTrainingProviderId > 0)
            {
                operationStatus = GetVocationalTrainingProviderDbService().RemoveVocationalTrainingProvider(vocationalTrainingProviderId);
            }

            return Ok(operationStatus);
        }

        #endregion CRUD Operations

        #region Private

        private IVocationalTrainingProviderDbService GetVocationalTrainingProviderDbService()
        {
            IVocationalTrainingProviderDbService service = new VocationalTrainingProviderDbService();
            return service;
        }

        #endregion Private
    }
}
