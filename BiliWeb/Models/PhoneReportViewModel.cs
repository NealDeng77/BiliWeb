using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiliWeb.Models
{
    /// <summary>
    /// PhoneReportViewModel class
    /// </summary>
    public class PhoneReportViewModel
    {
        /// <summary>
        /// The PhoneModel for this PhoneReportViewModel
        /// </summary>
        public PhoneModel PhoneModel { get; set; }

        /// <summary>
        /// The current operating system installed on the phone
        /// </summary>
        public VersionOSModel CurrentOSVersion { get; set; }

        /// <summary>
        /// The current app version installed on the phone
        /// </summary>
        public VersionAppModel CurrentAppVersion { get; set; }

        /// <summary>
        /// The phone's operating system history. 
        /// </summary>
        public List<HistoryOSModel> PhoneOSHistory = new List<HistoryOSModel>();

        /// <summary>
        /// The phone's application version history
        /// </summary>
        public List<HistoryAppModel> PhoneAppHistory = new List<HistoryAppModel>();

        /// <summary>
        /// The date that the application was initially installed on this phone
        /// </summary>
        public DateTime InitialInstall { get; set; }

        /// <summary>
        /// The last time that this phone was heard from in any capacity 
        /// </summary>
        public DateTime LastHeardFrom { get; set; }

        // TODO: add more attributes here as needed 
    }
}
