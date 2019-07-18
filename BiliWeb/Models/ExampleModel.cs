using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiliWeb.Models
{
    /// <summary>
    ///  Example Data Model
    /// </summary>
    public class ExampleModel
    {
        // The ID for this data record as a guid
        public string ExampleID { get; set; } = System.Guid.NewGuid().ToString("D");

        // Just a field to show how to use it...
        public string Name { get; set; }

    }
}
