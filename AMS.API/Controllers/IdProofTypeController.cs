using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AMS.API.Controllers
{
    [RoutePrefix("api")]
    public class IdProofTypeController : BaseApiController
    {
        #region CRUD Operations

        //Get: IdProofType
        /// <summary>
        /// Get list of IdProofType based on id i.e. specific or all
        /// </summary>
        /// <param name="schemeId"></param>
        /// <returns></returns>
        [Route("IdProofDocumentType/{IdProofTypeId?}")]
        public IHttpActionResult Get(int schemeId = 0)
        {
            return Ok();
            //return Ok(GetIdProofTypeDbService().GetIdProofTypes(IdProofTypeId);
        }

        #endregion CRUD Operations

        #region Private

        //private IIdProofTypeDbService GetIdProofTypeDbService()
        //{
        //    IIdProofTypeDbService service = new IdProofTypeDbService();
        //    return service;
        //}

        #endregion Private
    }
}