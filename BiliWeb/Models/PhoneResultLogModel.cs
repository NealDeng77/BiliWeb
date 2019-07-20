
namespace BiliWeb.Models
{
    /// <summary>
    /// The result returned to the Phone App with the results of the Log Mesage Post from the Phone to the Server
    /// 
    /// Status
    ///     If success return 1
    ///     If Fail return 0
    ///     
    /// Message
    ///     When Sucess return OK
    ///     When Error, return why
    ///
    /// ResultLogID
    ///     The record created with this request
    ///          
    /// PhoneID
    ///     The Photo record created to match this log, will be used for the photo upload location
    /// </summary>
    public class PhoneResultLogModel
    {
        // Status of the request
        public int Status { get; set; } = 0;

        // The Message from the system, OK is success, else why there is an error
        public string Message { get; set; } = "OK";

        // The record created for this request
        public string ResultLogID { get; set; } = null;

        // The Photo ID to use for the photo upload
        public string PhotoID { get; set; } = null;

    }
}