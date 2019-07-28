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
    public class HistoryAppRepositoryDataHelper
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile HistoryAppRepositoryDataHelper instance;
        private static readonly object syncRoot = new Object();

        private HistoryAppRepositoryDataHelper() { }

        public static HistoryAppRepositoryDataHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new HistoryAppRepositoryDataHelper();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The AvatarItem List
        /// </summary>
        private List<HistoryAppModel> DataList = new List<HistoryAppModel>();

        /// <summary>
        /// Clear the Data List, and build up a new one
        /// </summary>
        /// <returns></returns>
        public List<HistoryAppModel> GetDefaultDataSet()
        {
            DataList.Clear();

            DataList.Add(new HistoryAppModel { Name = "Mike" }); // Default
            DataList.Add(new HistoryAppModel { Name = "Doug" }); 
            DataList.Add(new HistoryAppModel { Name = "Jea" }); 
            DataList.Add(new HistoryAppModel { Name = "Sue" }); 

            return DataList;
        }

    }
}