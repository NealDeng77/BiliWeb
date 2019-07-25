using Microsoft.AspNetCore.Mvc;
using BiliWeb.Models;

namespace BiliWeb.Controllers
{


    /// <summary>
    /// The URL the Phone will send the Result Logs to
    /// </summary>
    [Route("api/[controller]/{SerialNumber}")]
    [ApiController]
    public class PhoneSettingsController : ControllerBase
    {
        /// <summary>
        /// Return the settings to the Phone to use.
        /// 
        /// </summary>
        /// <returns>
        /// PhoneID
        /// User List for this Phone to select From
        /// Clinic List for this Phone to Select From
        /// </returns>
        [HttpGet]
        public PhoneSettingsModel Get(string SerialNumber)
        {

            var data = new PhoneSettingsModel();

            if (string.IsNullOrEmpty(SerialNumber))
            {
                return data;
            }

            var dataPhone = Backend.PhoneHelper.ConvertSerialNumberToPhoneModel(SerialNumber);
            if (dataPhone == null)
            {
                return data;
            }

            data = new PhoneSettingsModel(dataPhone);
            data.Status = 1;
            data.Message = "OK";

            return data;
        }
    }
}