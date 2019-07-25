
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
    public class PhoneResultLogModel : APIBaseModel
    {
        // The record created for this request
        public string ResultLogID { get; set; } = null;

        // The Photo ID to use for the photo upload
        public string PhotoID { get; set; } = null;

        // FormDataID - The ID to pass to the Form to access it
        public string ResultDataID { get; set; } = null;

        // FormURI - The Controller/Action to send the web page request to
        public string ResultDataURI { get; set; } = "/PhoneResultForm/Update/";

    }
}