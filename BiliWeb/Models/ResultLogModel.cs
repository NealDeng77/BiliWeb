using System;
using System.Collections.Generic;
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
    public class ResultLogModel
    {
        // The Guid for this Record
        public string ResultLogID { get; set; } = new Guid().ToString();

        // The Date Time in UTC when this record was created
        public DateTime ResultLogDateTime { get; set; } = DateTime.UtcNow;

        // The Bilirubin result Value
        public double BilirubinValue { get; set; }

        // The guid to the Clinic where the value was recorded
        public string ClinicID { get; set; }

        // The guid to the Phone that took the picture
        public string PhoneID { get; set; }

        // The guid to the User who took the pictures
        public string UserID { get; set; }

        // The guid to the photo set for this record, created here and passed back to the phone, and thus used for storing the photos
        public string PhotoID { get; set; } = new Guid().ToString();
    }
}
