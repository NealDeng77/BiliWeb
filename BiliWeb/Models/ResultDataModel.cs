using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BiliWeb.Models
{
    /// <summary>
    ///  Example Data Model
    /// </summary>
    public class ResultDataModel : BaseModel
    {
        // 4 letter code that matches this result back to the Phone Result so that technicians don't have to enter the entire quid.
        [Display(Name = "Result Code")]
        public string ResultCode { get; set; } = Backend.ResultDataHelper.GenerateResultCode();

        // Result of the Lab, to compare with the Photo Value
        [Display(Name = "Lab Result")]
        public double LabResult { get; set; }

        /// <summary>
        /// Simple Constructor
        /// </summary>
        /// <param name="data"></param>
        public ResultDataModel()
        {
        //    GenerateResultCode();
        }

        /// <summary>
        /// Makes a copy of the data
        /// </summary>
        /// <param name="data"></param>
        public ResultDataModel(ResultDataModel data)
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
        public bool Update(ResultDataModel data)
        {
            if (data == null)
            {
                return false;
            }

            // Don't update the ID, leave the old one in place
            // ID = data.ID;

            // Don't update the Date, leave the old one in place
            // Date = data.Date;

            // Don't update the Access Code Result Code
            // ResultCode = data.ResultCode;

            // Update all the other fields
            LabResult = data.LabResult;

            return true;
        }
    }
}
