using System;
using Microsoft.AspNetCore.Http;
using System.Web;

namespace BiliWeb.Models
{
    /// <summary>
    /// System wide Global variables
    /// </summary>
    public class SystemGlobalsModel
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile SystemGlobalsModel instance;
        private static readonly object syncRoot = new Object();

        private SystemGlobalsModel() { }

        public static SystemGlobalsModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new SystemGlobalsModel();
                            Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        // The Enum to use for the current data source
        // Default to Mock
        private static DataSourceEnum _DataSourceValue;

        public DataSourceEnum DataSourceValue => _DataSourceValue;

        #region MikeFixup
        /* Mike
         * Need to refactor the old http context code, to use the new asp core approach.
         * Need to get the current running URL so on boot the system can choose which data source to use
         * For now, it will default to the dev mode
         */

        /// <summary>
        /// Initilize the site with the default context
        /// </summary>
        public static void Initialize()
        {
        //    var myCurrentURL = GetCurrentHostURL(Microsoft.AspNetCore.Http.HttpContext context);
            var myDataSoruceEnum = SelectDataSourceEnum("bogus");
            SetDataSourceEnum(myDataSoruceEnum);

            return;
        }

        ///// <summary>
        ///// Get the Host URL if not specified
        ///// Used to determine to default to SQL or Local
        ///// Dev run local
        ///// </summary>
        ///// <param name="context"></param>
        ///// <returns></returns>
        //public static string GetCurrentHostURL(HttpContext context)
        //{
        //    string myReturn = null;

        //    if (context == null)
        //    {
        //        return myReturn;
        //    }

        //    if (string.IsNullOrEmpty(context.Request.Url.Host))
        //    {
        //        return myReturn;
        //    }

        //    myReturn = context.Request.Url.Host;
        //    return myReturn;
        //}
        #endregion MikeFixup

        /// <summary>
        /// Pick The Data Source base on the URL
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        public static DataSourceEnum SelectDataSourceEnum(string choice)
        {
            var myReturn = DataSourceEnum.Mock;

            if (choice == null)
            {
                return myReturn;
            }

            if (choice.Contains("BiliWeb.azurewebsites.net"))
            {
                return DataSourceEnum.ServerLive;
            }

            if (choice.Contains("azurewebsites.net"))
            {
                return DataSourceEnum.ServerTest;
            }

            return myReturn;
        }

        /// <summary>
        /// Sets the Data Source Enum
        /// </summary>
        /// <param name="SetDataSourceValue"></param>
        public static void SetDataSourceEnum(DataSourceEnum SetDataSourceValue)
        {
            _DataSourceValue = SetDataSourceValue;
        }
    }
}