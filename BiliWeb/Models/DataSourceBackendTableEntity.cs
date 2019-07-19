using Microsoft.WindowsAzure.Storage.Table;

namespace BiliWeb.Models
{
    /// <summary>
    /// This Converts a Table Entity to a Json Format for Retreival
    /// Used to Store the Data into the Azure Table Storage which is a Key Value Pair Store.
    /// </summary>
    public class DataSourceBackendTableEntity : TableEntity
    {

        /// <summary>
        /// data blob to store
        /// A Json format of the desired data package
        /// Needs to be converted to Json and passed in
        /// Results, need to be convered from TableEntity and parsed 
        /// </summary>
        public string Blob { get; set; }

        public DataSourceBackendTableEntity(string pk, string rk, string blob)
            : base(pk, rk)
        {
            Blob = blob;
        }

        public DataSourceBackendTableEntity(string pk, string rk)
            : base(pk, rk) { }

        public DataSourceBackendTableEntity() { }
    }
}