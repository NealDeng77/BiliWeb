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

            DataList.Add(new VersionAppModel { Name = "Mike" }); // Default
            DataList.Add(new VersionAppModel { Name = "Doug" }); 
            DataList.Add(new VersionAppModel { Name = "Jea" }); 
            DataList.Add(new VersionAppModel { Name = "Sue" }); 

            return DataList;
        }

    }
}