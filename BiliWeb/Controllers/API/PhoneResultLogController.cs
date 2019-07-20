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
        /// <param name="value"></param>
        // POST: api/PhoneService
        [HttpPost]
//        public void Post([FromBody] ResultLogModel value)
        public void Post(ResultLogModel value)
        {
            var a = value.ClinicID;
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
