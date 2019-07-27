using System;
using System.Web;
using BiliWeb.Backend;
using BiliWeb.Models;

namespace BiliWeb.Backend
{
    /// <summary>
    /// Class that manages the overall data sources
    /// </summary>
    public class DataSourceBackend
    {
        /// <summary>
        /// Hold one of each of the DataSources as an instance to the datasource
        /// </summary>
        public ExampleBackend ExampleBackend = ExampleBackend.Instance;
        public PhotoBackend PhotoBackend = PhotoBackend.Instance;
        public ClinicBackend ClinicBackend = ClinicBackend.Instance;
        public ResultLogBackend ResultLogBackend = ResultLogBackend.Instance;
        public ResultDataBackend ResultDataBackend = ResultDataBackend.Instance;
        public PhoneBackend PhoneBackend = PhoneBackend.Instance;
        public TechnicianBackend TechnicianBackend = TechnicianBackend.Instance;
        public InventoryBackend InventoryBackend = InventoryBackend.Instance;
        public VersionOSBackend VersionOSBackend = VersionOSBackend.Instance;
        public VersionAppBackend VersionAppBackend = VersionAppBackend.Instance;
        public HistoryOSBackend HistoryOSBackend = HistoryOSBackend.Instance;
        // Add YourName Above Here  #1


        private DataSourceBackend()
        {
            ExampleBackend = ExampleBackend.Instance;
            PhotoBackend = PhotoBackend.Instance;
            ClinicBackend = ClinicBackend.Instance;
            ResultLogBackend = ResultLogBackend.Instance;
            ResultDataBackend = ResultDataBackend.Instance;
            PhoneBackend = PhoneBackend.Instance;
            TechnicianBackend = TechnicianBackend.Instance;
            InventoryBackend = InventoryBackend.Instance;
            VersionOSBackend = VersionOSBackend.Instance;
            VersionAppBackend = VersionAppBackend.Instance;
            HistoryOSBackend = HistoryOSBackend.Instance;
            // Add YourName Above Here #2
        }

        /// <summary>
        /// Call for all data sources to reset
        /// </summary>
        public void Reset()
        {
            ExampleBackend.Reset();
            PhotoBackend.Reset();
            ClinicBackend.Reset();
            ResultLogBackend.Reset();
            ResultDataBackend.Reset();
            PhoneBackend.Reset();
            TechnicianBackend.Reset();
            InventoryBackend.Reset();
            VersionOSBackend.Reset();
            VersionAppBackend.Reset();
            HistoryOSBackend.Reset(); 
            // Add YourName Above Here #3


            SetTestingMode(false);
        }

        /// <summary>
        /// Change between demo, default, and UT data sets
        /// </summary>
        /// <param name="SetEnum"></param>
        public void SetDataSourceDataSet(DataSourceDataSetEnum SetEnum)
        {
            ExampleBackend.SetDataSourceDataSet(SetEnum);
            PhotoBackend.SetDataSourceDataSet(SetEnum);
            ClinicBackend.SetDataSourceDataSet(SetEnum);
            ResultLogBackend.SetDataSourceDataSet(SetEnum);
            ResultDataBackend.SetDataSourceDataSet(SetEnum);
            PhoneBackend.SetDataSourceDataSet(SetEnum);
            TechnicianBackend.SetDataSourceDataSet(SetEnum);
            InventoryBackend.SetDataSourceDataSet(SetEnum);
            VersionOSBackend.SetDataSourceDataSet(SetEnum);
            VersionAppBackend.SetDataSourceDataSet(SetEnum);
            HistoryOSBackend.SetDataSourceDataSet(SetEnum); 
            // Add YourName Above Here #4
        }

        #region hide

        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile DataSourceBackend instance;
        private static readonly object syncRoot = new Object();

        private static bool isTestingMode = false;

        public static DataSourceBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DataSourceBackend();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Changes the data source, does not call for a reset, that allows for how swapping but keeping the original data in place
        /// </summary>
        public void SetDataSource(DataSourceEnum dataSourceEnum)
        {
            // Set the Global DataSourceEnum Value
            SystemGlobalsModel.SetDataSourceEnum(dataSourceEnum);
        }

        public static bool GetTestingMode()
        {
            return isTestingMode;
        }

        public static bool SetTestingMode(bool mode)
        {
            isTestingMode = mode;

            //set the testing mode for other backends
            //DataSourceBackend.SetTestingMode(mode);
            //Backend.StudentDataSourceMock.SetTestingMode(mode);

            return isTestingMode;
        }

        //public bool IsUserNotInRole(string userID, BiliWeb.Models.UserRoleEnum role)
        //{
        //    if (isTestingMode)
        //    {
        //        return false; // all OK
        //    }

        //    if (IdentityBackend.UserHasClaimOfType(userID, role))
        //    {
        //        return false;
        //    }
        //    return true; // Not in role, so error
        //}

        //public object CreateCookie(string testCookieName, string testCookieValue, HttpContextBase @object)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion hide
    }
}