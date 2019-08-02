using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiliWeb.Models
{
    /// <summary>
    /// Result Log Model
    /// 
    /// Holds the result of the data passed up from the Phone to the server.
    /// 
    /// The Photo is passed in a separate call based on the guid created
    /// </summary>
    public class ResultLogModel : BaseModel
    {
        // The Bilirubin result Value
        [Display(Name = "Bilirubin Value")]
        public double BilirubinValue { get; set; }

        // The guid to the Clinic where the value was recorded
        [Display(Name = "Clinic ID")]
        public string ClinicID { get; set; }

        // The guid to the Phone that took the picture
        [Display(Name = "Phone ID")]
        public string PhoneID { get; set; }

        // The guid to the User who took the pictures
        [Display(Name = "User ID")]
        public string UserID { get; set; }

        // The guid to the photo set for this record, created here and passed back to the phone, and thus used for storing the photos
        [Display(Name = "Photo ID")]
        public string PhotoID { get; set; } = System.Guid.NewGuid().ToString("D");

        // Some readings are duplicates of a parent reading.  This is to help with calibration.  This field tracks if there is a Parent or not for this reading
        [Display(Name = "Parent Reading")]
        public string ParentReadingID { get; set; } = null;

        // Reading Sequence tracks which sequence of image is this one, default is 1, but if there are more than 1 image, say 3, then it would be 1, 2, 3
        [Display(Name = "Reading Sequence")]
        public int ReadingSequence { get; set; } = 1;

        /// <summary>
        /// Simple Constructor
        /// </summary>
        /// <param name="data"></param>
        public ResultLogModel()
        {
        }

        /// <summary>
        /// Makes a copy of the data
        /// </summary>
        /// <param name="data"></param>
        public ResultLogModel(ResultLogModel data)
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
        public bool Update(ResultLogModel data)
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
            BilirubinValue = data.BilirubinValue;
            ClinicID = data.ClinicID;
            PhoneID = data.PhoneID;
            UserID = data.UserID;
            PhotoID = data.PhotoID;
            ParentReadingID = data.ParentReadingID;
            ReadingSequence = data.ReadingSequence;

            return true;
        }
    }
}
