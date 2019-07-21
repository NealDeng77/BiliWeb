using System;
using System.Collections.Generic;
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
        public string ClinicID { get; set; }

        // The device model of this phone. 
        public string DeviceModel { get; set; }

        // The serial number of this phone. 
        public string SerialNumber { get; set; }

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

            return true;
        }
    }
}
