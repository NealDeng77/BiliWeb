using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiliWeb.Models
{
    /// <summary>
    ///  Inventory Model
    /// </summary>
    public class InventoryModel : BaseModel
    {

        // The guid to the Clinic where the value was recorded
        [Display(Name = "Clinic ID")]
        public string ClinicID { get; set; }

        // The int count of current test strips in stock
        [Display(Name = "Test Strip Stock")]
        public int TestStripStock { get; set; }


        /// <summary>
        /// Simple Constructor
        /// </summary>
        /// <param name="data"></param>
        public InventoryModel()
        {
        }

        /// <summary>
        /// Makes a copy of the data
        /// </summary>
        /// <param name="data"></param>
        public InventoryModel(InventoryModel data)
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
        public bool Update(InventoryModel data)
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
            ClinicID = data.ClinicID;
            TestStripStock = data.TestStripStock;

            return true;
        }
    }
}
