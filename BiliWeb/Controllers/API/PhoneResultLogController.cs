using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BiliWeb.Models;
using BiliWeb.Backend;

namespace BiliWeb.Controllers
{
    /// <summary>
    /// The URL the Phone will send the Result Logs to
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneResultLogController : ControllerBase
    {
        /// <summary>
        /// The Phone will POST to the server a data object that will have the information needed to record the Log.
        /// After receiving a Log, the method will Call over to the Backend to Create a record
        /// It will reply back to the Phone with the PhotoID which will then be the guid used to upload the Photos
        /// </summary>
        /// <param name="value">
        /// 
        ///     A ResultLogModel
        ///     
        ///     ID is created at the server, not passed in
        ///     Date is set at the server, not passed in
        ///     PhotoID is ignored and instead generated and returned as part of the reply
        ///
        ///     ClinicID will be Validated
        ///     PhoneID will be Validated
        ///     UserID will be Validated
        ///     
        /// </param>
        // POST: api/PhoneService
        [HttpPost]
        public string Post([FromBody] ResultLogModel data)
        {
            // Todo Implement Security for api call, to prevent DOS attack

            if (data == null)
            {
                return "Error";
            }

            // Todo Validate Record paramaters
            // Range for Bilirubin Value
            // UserID
            // ClinicID
            // PhoneID

            var result = Backend.DataSourceBackend.Instance.ResultLogBackend.Create(data);

            //todo Return json package with status code, and result of ResultLogID and PhotoID

            /*
             * Return Object Will Include
             * ID - The ID of this object
             * PhotoID - The ID to send the Photos
             * Status: 0
             * String: OK
            */

            return "OK";
        }

        #region GetCalls
        /*
         * The Get Calls are for debuging only, after the Post is working and validated, they will be removed.
         */
        // GET: api/PhoneService
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PhoneService/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        #endregion GetCalls


    }
}
