using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiliWeb.Models
{
    public class PhoneReportViewModel
    {
        public PhoneModel PhoneModel { get; set; }

        public VersionOSModel CurrentOSVersion { get; set; }

        public VersionAppModel CurrentAppVersion { get; set; }

        // The list of HistoryOS records for this phone
        public List<HistoryOSModel> PhoneOSHistory = new List<HistoryOSModel>();

        // The list of HistoryApp records for this phone
        public List<HistoryAppModel> PhoneAppHistory = new List<HistoryAppModel>(); 

        public DateTime InitialInstall { get; set; }

        // The last time this phone was heard from in any capacity 
        public DateTime LastHeardFrom { get; set; }

        // add more attributes here as needed 
    }
}
