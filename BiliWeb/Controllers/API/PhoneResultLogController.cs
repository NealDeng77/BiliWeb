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
        public PhoneResultLogModel Post([FromBody] ResultLogModel data)
        {
            // Todo Implement Security for api call, to prevent DOS attack

            // Used for each of the Validity Checks
            bool isValid;

            // Create the result record, assume Fail
            var myReturn = new PhoneResultLogModel
            {
                Status = 0,
            };

            if (data == null)
            {
                myReturn.Message = "No Data";
                return myReturn;
            }

            // Todo Validate Record paramaters
            // Range for Bilirubin Value
            if (data.BilirubinValue <0 || data.BilirubinValue > 30)
            {
                myReturn.Message = "Data Range Error";
                return myReturn;
            }

            // Check UserID to ensrue it is Valid
            isValid = true; // Replace with call to Check UserID
            if (!isValid)
            {
                myReturn.Message = "Invalid User";
                return myReturn;
            }

            // Check ClinicID to ensrue it is Valid
            isValid = true; // Replace with call to Check ClinicID
            if (!isValid)
            {
                myReturn.Message = "Invalid User";
                return myReturn;
            }

            // Check PhoneID to ensrue it is Valid
            isValid = true; // Replace with call to Check PhoneID
            if (!isValid)
            {
                myReturn.Message = "Invalid Phone";
                return myReturn;
            }

            var result = DataSourceBackend.Instance.ResultLogBackend.Create(data);
            if (result == null)
            {
                myReturn.Message = "Failed To Create Record";
                return myReturn;
            }

            /*
             * All OK, so update the returned data set to have success, and the created ID for Log and Photo
             * Status: 1
             * String: OK
             * Return Object Will Include
             * ID - The ID of this object
             * PhotoID - The ID to send the Photos
            */

            myReturn.Status = 1;
            myReturn.Message = "OK";
            myReturn.ResultLogID = result.ID;
            myReturn.PhotoID = result.PhotoID;

            return myReturn;
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
