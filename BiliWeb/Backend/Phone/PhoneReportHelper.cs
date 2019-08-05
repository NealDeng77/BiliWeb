using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiliWeb.Models;

namespace BiliWeb.Backend.Phone
{
    /// <summary>
    /// Helper class for Phone Report View Model. 
    /// </summary>
    public static class PhoneReportHelper
    {
        /// <summary>
        /// Returns the VersionOSModel representing the 
        /// current Operating System of this phone
        /// </summary>
        /// <param name="PhoneID"></param>
        /// <returns></returns>
        public static VersionOSModel GetCurrentOSVersion(string PhoneID)
        {
            var HistoryOSQuery = QueryHistoryOSRecords(PhoneID);

            if (HistoryOSQuery.Count() == 0) // no records with PhoneID found
            {
                return null; 
            }

            // sort records by date ascending
            HistoryOSQuery = HistoryOSQuery.OrderBy(x => x.Date).ToList();

            // get VersionOSID from last item in query
            string VersionOSID = HistoryOSQuery.Last().VersionOSID;

            return BiliWeb.Backend.VersionOSBackend.Instance.Read(VersionOSID);
        }

        /// <summary>
        /// Returns the VersionAppModel representing the current
        /// version of the app installed on this phone
        /// </summary>
        /// <param name="PhoneID"></param>
        /// <returns></returns>
        public static VersionAppModel GetCurrentAppVersion(string PhoneID)
        {
            var HistoryAppQuery = QueryHistoryAppRecords(PhoneID);

            if (HistoryAppQuery.Count() == 0) // no records with PhoneID found
            {
                return null; 
            }

            // sort records by date ascending
            HistoryAppQuery = HistoryAppQuery.OrderBy(x => x.Date).ToList();

            // get VersionAppID of last item in the query
            string VersionAppID = HistoryAppQuery.Last().VersionAppID;

            return BiliWeb.Backend.VersionAppBackend.Instance.Read(VersionAppID);
        }

        /// <summary>
        /// Obtains all of the HistoryOS records for this 
        /// phone ordered by date ascending. 
        /// </summary>
        /// <param name="PhoneID"></param>
        /// <returns></returns>
        public static List<HistoryOSModel> GetPhoneHistoryOS(string PhoneID)
        {
            // return list of HistoryOS records ordered by Date
            return QueryHistoryOSRecords(PhoneID).OrderBy(x => x.Date).ToList(); 
        }
        
        /// <summary>
        /// Obtains all of the HistoryApp records for this
        /// phone ordered by date ascending. 
        /// </summary>
        /// <param name="PhoneID"></param>
        /// <returns></returns>
        public static List<HistoryAppModel> GetPhoneHistoryApp(string PhoneID)
        {
            // return list of HistoryApp records ordered by Date
            return QueryHistoryAppRecords(PhoneID).OrderBy(x => x.Date).ToList(); 
        }

        /// <summary>
        /// Retrieves the date that the app was initially 
        /// installed on this phone 
        /// </summary>
        /// <param name="PhoneID"></param>
        /// <returns></returns>
        public static DateTime GetInitialInstallDate(string PhoneID)
        {
            return QueryHistoryAppRecords(PhoneID).OrderBy(x => x.Date).ToList().First().Date; 
        }
        
        /// <summary>
        /// Retrieves the time this phone was last
        /// heard from
        /// </summary>
        /// <param name="PhoneID"></param>
        /// <returns></returns>
        public static DateTime GetLastHeardDate(string PhoneID)
        {
            throw new NotImplementedException(); 

            // last time phone heard from 
        }

        #region Helper Methods

        /// <summary>
        /// Retrieves all HistoryOS records for this phone
        /// </summary>
        /// <param name="PhoneID"></param>
        /// <returns></returns>
        private static IEnumerable<HistoryOSModel> QueryHistoryOSRecords(string PhoneID)
        {
            // get all VersionOSRecords 
            var HistoryOSList = BiliWeb.Backend.HistoryOSBackend.Instance.Index();

            // get all HistoryOS records with this PhoneID
            var HistoryOSQuery =
                from HistoryOSRecord in HistoryOSList
                where HistoryOSRecord.PhoneID == PhoneID
                select HistoryOSRecord;

            return HistoryOSQuery; 
        }

        /// <summary>
        /// Retrieves all HistoryApp records for this phone
        /// </summary>
        /// <param name="PhoneID"></param>
        /// <returns></returns>
        private static IEnumerable<HistoryAppModel> QueryHistoryAppRecords(string PhoneID)
        {
            var HistoryAppList = BiliWeb.Backend.HistoryAppBackend.Instance.Index();

            var HistoryAppQuery =
                from HistoryAppRecord in HistoryAppList
                where HistoryAppRecord.PhoneID == PhoneID
                select HistoryAppRecord;

            return HistoryAppQuery; 
        }

        #endregion 
    }
}
