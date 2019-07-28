using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiliWeb.Models
{
    /// <summary>
    ///  HistoryApp Data Model
    /// </summary>
    public class HistoryAppModel : BaseModel
    {

        
        ///  <summary>
        ///  Getter and Setter for PhoneID
        ///  </summary>
        public string PhoneID { get; set; }

        /// <summary>
        /// Getter and Setter for VersionAppID
        /// </summary>
        public string VersionAppID { get; set; }

        /// <summary>
        /// Simple Constructor
        /// </summary>
        /// <param name="data"></param>
        public HistoryAppModel()
        {
        }

        /// <summary>
        /// Makes a copy of the data
        /// </summary>
        /// <param name="data"></param>
        public HistoryAppModel(HistoryAppModel data)
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
        public bool Update(HistoryAppModel data)
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
            PhoneID= data.PhoneID;
            VersionAppID = data.VersionAppID;

            return true;
        }
    }
}
