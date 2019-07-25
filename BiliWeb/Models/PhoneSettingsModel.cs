using System.Collections.Generic;
using System.Linq;

namespace BiliWeb.Models
{
    /// <summary>
    /// Used to send to the Phone the settings it can use
    /// </summary>
    public class PhoneSettingsModel
    {

        // The Phone ID to use for this Phone
        public PhoneModel PhoneModel { get; set; }

        // The List of Clinics
        public ClinicModel ClinicModel { get; set; }

        // The List of Users for this Clinic
        public List<TechnicianModel> UserList { get; set; } = new List<TechnicianModel>();

        /// <summary>
        /// Constructor for class
        /// </summary>
        public PhoneSettingsModel(PhoneModel data)
        {
            // Get Phone based on the ID passed in
            PhoneModel = data;

            // Determine the Clinic from the Phone
            var PhoneClinic = PhoneModel.ClinicID;

            // Get the Clinic Information for that Phone
            ClinicModel = Backend.DataSourceBackend.Instance.ClinicBackend.Read(PhoneClinic);

            // Get the Users that are part of that Clinic
            // Todo, narrow this down to only the users that make since given the Clinic and Phone
            UserList = Backend.DataSourceBackend.Instance.TechnicianBackend.Index();
        }
    }
}
