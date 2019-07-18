using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiliWeb.Models
{
    /// <summary>
    ///  Base Model all data models inherit from
    ///  Contains the guid, and the data for the record
    /// </summary>
    public class BaseModel
    {

        // The ID for this data record as a guid
        public string ID { get; set; } = System.Guid.NewGuid().ToString("D");

        // When the record was created
        public DateTime Date { get; set; } = System.DateTime.UtcNow;

    }
}
