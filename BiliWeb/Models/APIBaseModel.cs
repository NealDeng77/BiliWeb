
namespace BiliWeb.Models
{
    /// <summary>
    /// Base for the API Models
    /// 
    /// Returns the Status, defualt is 0 false = Error
    /// Returns the Message, default is Error
    /// </summary>
    public class APIBaseModel
    {
        // Status of the request, Assume 0 Fail by default
        public int Status { get; set; } = 0;

        // The Message from the system, OK is success, else Error or Error Messsage
        public string Message { get; set; } = "Error";
    }
}