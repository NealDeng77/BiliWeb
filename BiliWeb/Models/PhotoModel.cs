using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiliWeb.Models
{
    /// <summary>
    ///  Photo Model
    /// </summary>
    public class PhotoModel : BaseModel
    {

        // The device which takes and updates the photo
        public string Device { get; set; }
        
        // Whether the photo is ok or error
        public int Status { get; set; }
        
        // Note of the photo
        public string Note { get; set; }

        // test score
        public double Score { get; set; }


        /// <summary>
        /// Simple Constructor
        /// </summary>
        /// <param name="data"></param>
        public PhotoModel()
        {
        }

        /// <summary>
        /// Makes a copy of the data
        /// </summary>
        /// <param name="data"></param>
        public PhotoModel(PhotoModel data)
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
        public bool Update(PhotoModel data)
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
            Device= data.Device;
            Status = data.Status;
            Note = data.Note;
            Score = data.Score;

            return true;
        }
    }
}
