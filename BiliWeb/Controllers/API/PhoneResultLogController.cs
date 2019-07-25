using Microsoft.AspNetCore.Mvc;
using BiliWeb.Models;
using BiliWeb.Backend;
using System.Collections.Generic;

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

            // Range for Bilirubin Value
            if (data.BilirubinValue <0 || data.BilirubinValue > 30)
            {
                myReturn.Message = "Data Range Error";
                return myReturn;
            }

            // Check UserID to ensure it is Valid
            if (TechnicianBackend.Instance.Read( data.UserID ) is null )
            {
                myReturn.Message = "Invalid User";
                return myReturn;
            }

            // Check ClinicID to ensure it is Valid
            if ( ClinicBackend.Instance.Read( data.ClinicID ) is null )
            {
                myReturn.Message = "Invalid Clinic";
                return myReturn;
            }

            // Check PhoneID to ensure it is Valid
            if ( PhoneBackend.Instance.Read( data.PhoneID) is null )
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
             * FormDataID - The ID to pass to the Form to access it
             * FormURI - The Controller/Action to send the web page request to
             */

            myReturn.Status = 1;
            myReturn.Message = "OK";
            myReturn.ResultLogID = result.ID;
            myReturn.PhotoID = result.PhotoID;

            // myReturn.ResultDataURI = Use the default for now that is in the model
            myReturn.ResultDataID = DataSourceBackend.Instance.ResultDataBackend.CreateNewEmpty().ID;

            return myReturn;
        }
    }
}
