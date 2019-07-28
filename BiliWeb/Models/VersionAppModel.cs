using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiliWeb.Models
{
    /// <summary>
    ///  VersionOS Data Model
    /// </summary>
    public class VersionAppModel : BaseModel
    {

        /// <summary>
        /// The name of this version of the phone app. 
        /// </summary>
        [Display(Name = "App Version")]
        public string VersionAppName { get; set; }

        /// <summary>
        ///  The release notes for this version of the app. 
        /// </summary>
        [Display(Name = "Release Notes")]
        public string ReleaseNotes { get; set; }

        /// <summary>
        /// Simple Constructor
        /// </summary>
        /// <param name="data"></param>
        public VersionAppModel()
        {
        }

        /// <summary>
        /// Makes a copy of the data
        /// </summary>
        /// <param name="data"></param>
        public VersionAppModel(VersionAppModel data)
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
        public bool Update(VersionAppModel data)
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
            VersionAppName = data.VersionAppName;
            ReleaseNotes = data.ReleaseNotes;

            return true;
        }
    }
}
