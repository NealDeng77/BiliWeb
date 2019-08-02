using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiliWeb.Models
{
    /// <summary>
    ///  Phone Data Model
    /// </summary>
    public class PhoneModel : BaseModel
    {

        // The guid to this phone's clinic. 
        [Display(Name = "Clinic ID")]
        public string ClinicID { get; set; }

        // The device model of this phone. 
        [Display(Name = "Device Model")]
        public string DeviceModel { get; set; }

        // The serial number of this phone. 
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        // The timeout in Miliseconds for this phone
        [Display(Name = "Timeout ms")]
        public int TimeOut { get; set; } = 10000;

        // The number of readings the phone should take, default is 1 reading, 1 picture
        [Display(Name = "Number of Readings")]
        public int ReadingCaptureCount { get; set; } = 1;

        /// <summary>
        /// Simple Constructor
        /// </summary>
        /// <param name="data"></param>
        public PhoneModel()
        {
        }

        /// <summary>
        /// Makes a copy of the data
        /// </summary>
        /// <param name="data"></param>
        public PhoneModel(PhoneModel data)
        {
            // Because this is a copy, let it have a new ID
            Update(data);
        }

        /// <summary>
        /// Update fields passed in
        /// Updates all fields to be the values passed in
        /// Does NOT update the ID field, this allows for the method to be used as part of a copy.
        /// Does NOT update the Date field, this allows for the method to be used as part of a copy.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(PhoneModel data)
        {
            if (data == null)
            {
                return false;
            }

            // Don't update the ID, leave the old one in place
            // ID = data.ID;

            // Don't update the Date, leave the old one in place
            // Date = data.Date;

            // Update all the other fields
            ClinicID = data.ClinicID;
            DeviceModel = data.DeviceModel;
            SerialNumber = data.SerialNumber;
            TimeOut = data.TimeOut;
            ReadingCaptureCount = data.ReadingCaptureCount;

            return true;
        }
    }
}
