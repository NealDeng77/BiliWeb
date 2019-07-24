using System;
using System.Collections.Generic;

using BiliWeb.Models;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace BiliWeb.Backend
{
    /// <summary>
    /// Backend Table DataSource for AvatarItems, to manage them
    /// </summary>
    public class VersionOSRepositoryDataHelper
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile VersionOSRepositoryDataHelper instance;
        private static readonly object syncRoot = new Object();

        private VersionOSRepositoryDataHelper() { }

        public static VersionOSRepositoryDataHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new VersionOSRepositoryDataHelper();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The AvatarItem List
        /// </summary>
        private List<VersionOSModel> DataList = new List<VersionOSModel>();

        /// <summary>
        /// Clear the Data List, and build up a new one
        /// </summary>
        /// <returns></returns>
        public List<VersionOSModel> GetDefaultDataSet()
        {
            DataList.Clear();

            DataList.Add(new VersionOSModel { VersionOSName = "3.0" }); // Default
            DataList.Add(new VersionOSModel { VersionOSName = "3.1" }); 
            DataList.Add(new VersionOSModel { VersionOSName = "3.2" }); 
            DataList.Add(new VersionOSModel { VersionOSName = "3.3" }); 

            return DataList;
        }

    }
}