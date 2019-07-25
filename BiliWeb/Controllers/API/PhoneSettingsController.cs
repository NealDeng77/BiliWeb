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
        public PhoneSettingsModel Get()
        {
            var data = new PhoneSettingsModel();
            return data;
        }
    }
}