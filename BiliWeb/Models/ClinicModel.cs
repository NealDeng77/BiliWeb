using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiliWeb.Models
{
    /// <summary>
    ///  Example Data Model
    /// </summary>
    public class ClinicModel : BaseModel
    {

        // Name of the clinic
        public string Name { get; set; }

        // Address of the clinic
        public string Address { get; set; }

        // City of the clinic
        public string City { get; set; }

        // Country of the clinic
        public string Country { get; set; }

        // Contact person of the clinic
        public string Contact { get; set; }

        // Phone number of the clinic
        public string Phone { get; set; }

        // Email of the clinic
        public string Email { get; set; }

        // WhatsApp contact
        public string WhatsApp { get; set; }

        // Notes of the clinic
        public string Notes { get; set; }

        // Latitude of the Location
        public string Latitude { get; set; }

        // Longitude of the Location
        public string Longitude { get; set; }

        /// <summary>
        /// Simple Constructor
        /// </summary>
        /// <param name="data"></param>
        public ClinicModel()
        {
        }

        /// <summary>
        /// Makes a copy of the data
        /// </summary>
        /// <param name="data"></param>
        public ClinicModel(ClinicModel data)
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
        public bool Update(ClinicModel data)
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
            Name = data.Name;
            Address = data.Address;
            City = data.City;
            Country = data.Country;
            Contact = data.Contact;
            Phone = data.Phone;
            Email = data.Email;
            WhatsApp = data.WhatsApp;
            Notes = data.Notes;
            Latitude = data.Latitude;
            Longitude = data.Longitude;

            return true;
        }
    }
}
