﻿using Microsoft.AspNetCore.Mvc;
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
        /// Is it a valid technician id
        /// </summary>
        /// <param name="id">string technician id</param>
        /// <returns>True if it is a valid technician id, false otherwise</returns>
        public bool isValidTechnician(string id)
        {
            //Call backend to technicians
            TechnicianBackend TechnicianData = TechnicianBackend.Instance;
            List<TechnicianModel> tech = TechnicianData.Index();

            foreach (TechnicianModel t in tech)
            {
                if ( t.ID.Equals(id) )
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Is it a valid clinic id
        /// </summary>
        /// <param name="id">string id of clinic</param>
        /// <returns>True if valid, false otherwise.</returns>
        public bool isValidClinic( string id)
        {
            //Call backend to clinics
            ClinicBackend ClinicData = ClinicBackend.Instance;
            List<ClinicModel> clinic = ClinicData.Index();

            foreach ( ClinicModel c in clinic )
            {
                if( c.ID.Equals( id))
                {
                    return true;
                }
            }
            return false;

        }

        /// <summary>
        /// Is it a valid phone 
        /// </summary>
        /// <param name="id">string phone id</param>
        /// <returns>True if valid, false otherwise. </returns>
        public bool isValidPhone( string id )
        {
            PhoneBackend PhoneData = PhoneBackend.Instance;
            List<PhoneModel> phones = PhoneData.Index();

            foreach( PhoneModel p in phones)
            {
                if( p.ID.Equals( id ))
                {
                    return true;
                }
            }
            return false;
        }

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

            // Todo Update to validate
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
            if (!isValidTechnician( data.UserID ) )
            {
                myReturn.Message = "Invalid User";
                return myReturn;
            }

            // Check ClinicID to ensrue it is Valid
            isValid = true; // Replace with call to Check ClinicID
            if (!isValidClinic( data.ClinicID ) )
            {
                myReturn.Message = "Invalid User";
                return myReturn;
            }

            // Check PhoneID to ensrue it is Valid
            isValid = true; // Replace with call to Check PhoneID
            if (!isValidPhone( data.PhoneID ))
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
            myReturn.ResultDataID = "form guid"; //TODO, call to the ResultFrom and create a new guid

            return myReturn;
        }
    }
}
