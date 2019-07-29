using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiliWeb.Models
{
    /// <summary>
    ///  Example Data Model
    /// </summary>
    public class ResultDataModel : BaseModel
    {
        // Just a field to show how to use it...
        public string Name { get; set; }

        // 4 letter code that matches this result back to the Phone Result so that technicians don't have to enter the entire quid.
        public string ResultCode { get; set; }

        // Result of the Lab, to compare with the Photo Value
        public double LabResult { get; set; }

        // Random Number Generator
        private Random _random = new Random();

        /// <summary>
        /// Simple Constructor
        /// </summary>
        /// <param name="data"></param>
        public ResultDataModel()
        {
            GenerateResultCode();
        }

        /// <summary>
        /// Makes a copy of the data
        /// </summary>
        /// <param name="data"></param>
        public ResultDataModel(ResultDataModel data)
        {
            GenerateResultCode();
            // Because this is a copy, let it have a new ID
            Update(data);
        }

        /// <summary>
        /// Create a didget random string, used as the code
        /// Not important if it repeats, because the PhoneRecord will check to see if the Code matches the expected Guid
        /// </summary>
        /// <returns>000001 - 999999 as a string</returns>
        public string GenerateResultCode()
        {
            ResultCode = _random.Next(0, 1000000).ToString("D6");
            return ResultCode;
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

            // Update all the other fields
            Name= data.Name;

            LabResult = data.LabResult;
            ResultCode = data.ResultCode;

            return true;
        }
    }
}
