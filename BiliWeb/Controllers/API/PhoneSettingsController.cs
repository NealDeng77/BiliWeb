using Microsoft.AspNetCore.Mvc;
using BiliWeb.Models;

namespace BiliWeb.Controllers
{


    /// <summary>
    /// The URL the Phone will send the Result Logs to
    /// </summary>
    [Route("api/[controller]")]
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
            if (string.IsNullOrEmpty(SerialNumber))
            {
                return null;
            }

            var dataPhone = BiliWeb.Backend.PhoneHelper.ConvertSerialNumberToPhoneModel(SerialNumber);
            if (dataPhone == null)
            {
                return null;
            }

            var data = new PhoneSettingsModel(dataPhone);
            return data;
        }
    }
}