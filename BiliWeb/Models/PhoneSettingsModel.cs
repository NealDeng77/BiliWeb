using System.Collections.Generic;

namespace BiliWeb.Models
{
    /// <summary>
    /// Used to send to the Phone the settings it can use
    /// </summary>
    public class PhoneSettingsModel : APIBaseModel
    {

        // The Phone ID to use for this Phone
        public PhoneModel PhoneModel { get; set; } = new PhoneModel();

        // The List of Users for this Clinic
        public List<TechnicianModel> UserList { get; set; } = new List<TechnicianModel>();

        /// <summary>
        /// Blank Constructor
        /// </summary>
        public PhoneSettingsModel()
        {

        }

        /// <summary>
        /// Constructor for class
        /// </summary>
        public PhoneSettingsModel(PhoneModel data)
        {
            // Get Phone based on the ID passed in
            PhoneModel = data;

            // Get the Users that are part of that Clinic
            // Todo, narrow this down to only the users that make since given the Clinic and Phone
            UserList = Backend.DataSourceBackend.Instance.TechnicianBackend.Index();
        }
    }
}
