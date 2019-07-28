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
    public class VersionAppRepositoryDataHelper
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile VersionAppRepositoryDataHelper instance;
        private static readonly object syncRoot = new Object();

        private VersionAppRepositoryDataHelper() { }

        public static VersionAppRepositoryDataHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new VersionAppRepositoryDataHelper();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The AvatarItem List
        /// </summary>
        private List<VersionAppModel> DataList = new List<VersionAppModel>();

        /// <summary>
        /// Clear the Data List, and build up a new one
        /// </summary>
        /// <returns></returns>
        public List<VersionAppModel> GetDefaultDataSet()
        {
            DataList.Clear();

            DataList.Add(new VersionAppModel { VersionAppName = "1.0" , ReleaseNotes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do " }); // Default
            DataList.Add(new VersionAppModel { VersionAppName = "1.1", ReleaseNotes = "eiusmod tempor incididunt ut labore et dolore magna aliqua. " }); 
            DataList.Add(new VersionAppModel { VersionAppName = "1.2", ReleaseNotes = "Ut enim ad minim veniam, quis nostrud exercitation ullamco " }); 
            DataList.Add(new VersionAppModel { VersionAppName = "1.3", ReleaseNotes = "laboris nisi ut aliquip ex ea commodo consequat. Duis aute " }); 

            return DataList;
        }

    }
}