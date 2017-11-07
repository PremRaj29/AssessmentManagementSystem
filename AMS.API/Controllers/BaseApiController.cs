using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMS.API.Controllers
{
    public class BaseApiController : ApiController
    {
        #region Constructors

        public BaseApiController() { }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Return the Model Error incase of server side validation fails
        /// </summary>
        /// <returns>custom error</returns>
        protected void GetModelValidationErrors(Uri serviceName, HttpMethod serviceMethod)
        {
            var messages = new List<string>();

            try
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        //var key = modelStateKey;
                        //var errorMessage = error.ErrorMessage;
                        //var exception = error.Exception;
                        var modelName = (modelStateKey.Contains(".") ? modelStateKey.Split('.')[0] : string.Empty);

                        //add validation error message
                        messages.Add(string.Format("Exception Details : {0}, {1}",modelName,error.ErrorMessage));
                    }
                }
            }
            catch
            {
                //loggingService.Fatal(string.Format("Method {0} executed with error message : {1}", MethodBase.GetCurrentMethod().Name, ex.Message));
            }

            throw new Exception("Data model validation exception");
        }

        /// <summary>
        /// Gets the model errors if there is any failure in server side validation.
        /// </summary>
        /// <returns>model errors</returns>
        protected string GetModelErrors()
        {
            ArrayList modelErrors = new ArrayList();
            try
            {
                foreach (string error in from state in ModelState.Values
                                         from error in state.Errors
                                         select error.ErrorMessage)
                {
                    modelErrors.Add(error);
                }
            }
            catch (Exception ex)
            {
                modelErrors.Add(ex.Message);
            }

            return string.Join(",", modelErrors.ToArray());
        }

        #endregion
    }
}
