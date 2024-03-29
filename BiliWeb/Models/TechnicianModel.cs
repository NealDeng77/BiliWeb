﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiliWeb.Models
{
    /// <summary>
    ///  Example Data Model
    /// </summary>
    public class TechnicianModel : BaseModel
    {

        // Tech's first name
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        // Tech's last name
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // Tech's DOB
        [Display(Name = "Date of Birth")]
        public Nullable<DateTime> DateOfBirth { get; set; }
        
        // Tech's clinic
        [Display(Name = "Clinic")]
        public string ClinicID { get; set; }
        /// <summary>
        /// Simple Constructor
        /// </summary>
        /// <param name="data"></param>
        public TechnicianModel()
        {
        }

        /// <summary>
        /// Makes a copy of the data
        /// </summary>
        /// <param name="data"></param>
        public TechnicianModel(TechnicianModel data)
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
        public bool Update(TechnicianModel data)
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
            FirstName = data.FirstName;
            LastName = data.LastName;
            DateOfBirth = data.DateOfBirth;
            ClinicID = data.ClinicID;

            return true;
        }
    }
}
