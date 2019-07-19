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

        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile DataSourceBackend instance;
        private static readonly object syncRoot = new Object();

        private static bool isTestingMode = false;

        private DataSourceBackend()
        {
            // Avatar must be before Student, because Student needs the default avatar
            ExampleBackend = ExampleBackend.Instance;
        }

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
        /// Call for all data sources to reset
        /// </summary>
        public void Reset()
        {
            ExampleBackend.Reset();

            SetTestingMode(false);
        }

        /// <summary>
        /// Changes the data source, does not call for a reset, that allows for how swapping but keeping the original data in place
        /// </summary>
        public void SetDataSource(DataSourceEnum dataSourceEnum)
        {
            // Set the Global DataSourceEnum Value
            SystemGlobalsModel.SetDataSourceEnum(dataSourceEnum);

        }

        /// <summary>
        /// Change between demo, default, and UT data sets
        /// </summary>
        /// <param name="SetEnum"></param>
        public void SetDataSourceDataSet(DataSourceDataSetEnum SetEnum)
        {
            ExampleBackend.SetDataSourceDataSet(SetEnum);
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
    }
}