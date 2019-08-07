using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using System.Collections.Generic;

namespace UnitTests.Models
{
    [TestClass]
    public class PhoneReportViewModelTests
    {
        /// <summary>
        /// Stand up a new PhoneReportViewModel, make sure it is not null
        /// </summary>
        [TestMethod]
        public void PhoneReportViewModel_Default_Should_Pass()
        {
            var data = new PhoneReportViewModel();

            Assert.IsNotNull(data);
        }

        /// <summary>
        /// Confirm that the attributes with getters are 
        /// null if they haven't been set, not null if 
        /// they are not set null by default. 
        /// </summary>
        [TestMethod]
        public void PhoneReportViewModel_Get_Should_Pass()
        {
            var data = new PhoneReportViewModel();

            Assert.IsNull(data.PhoneModel);
            Assert.IsNull(data.CurrentAppVersion);
            Assert.IsNull(data.CurrentOSVersion);
            Assert.IsNotNull(data.PhoneAppHistory); 
            Assert.IsNotNull(data.PhoneOSHistory); 
            Assert.IsNotNull(data.InitialInstall);
            Assert.IsNotNull(data.LastHeardFrom);
        }

        /// <summary>
        /// Confirm that attributes are set properly. 
        /// </summary>
        [TestMethod]
        public void PhoneReportViewModel_Set_Should_Pass()
        {

            // Prepare data
            PhoneModel phone = new PhoneModel();
            System.DateTime install = new System.DateTime();
            System.DateTime lastHeard = new System.DateTime();
            VersionAppModel appVersion = new VersionAppModel();
            VersionOSModel osVersion = new VersionOSModel();
            List<HistoryOSModel> myOSHistoryList = new List<HistoryOSModel>();
            List<HistoryAppModel> myAppHistoryList = new List<HistoryAppModel>();

            var data = new PhoneReportViewModel()
            {
                PhoneModel = phone,
                InitialInstall = install,
                LastHeardFrom = lastHeard,
                CurrentAppVersion = appVersion,
                CurrentOSVersion = osVersion,
            };

            data.PhoneOSHistory = myOSHistoryList;
            data.PhoneAppHistory = myAppHistoryList;

            Assert.AreEqual(phone, data.PhoneModel);
            Assert.AreEqual(install, data.InitialInstall);
            Assert.AreEqual(lastHeard, data.LastHeardFrom);
            Assert.AreEqual(appVersion, data.CurrentAppVersion);
            Assert.AreEqual(osVersion, data.CurrentOSVersion);
            Assert.AreEqual(myOSHistoryList, data.PhoneOSHistory);
            Assert.AreEqual(myAppHistoryList, data.PhoneAppHistory);
        }
    }
}
