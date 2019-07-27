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
    public class HistoryOSRepositoryDataHelper
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile HistoryOSRepositoryDataHelper instance;
        private static readonly object syncRoot = new Object();

        private HistoryOSRepositoryDataHelper() { }

        public static HistoryOSRepositoryDataHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new HistoryOSRepositoryDataHelper();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The AvatarItem List
        /// </summary>
        private List<HistoryOSModel> DataList = new List<HistoryOSModel>();

        /// <summary>
        /// Clear the Data List, and build up a new one
        /// </summary>
        /// <returns></returns>
        public List<HistoryOSModel> GetDefaultDataSet()
        {
            DataList.Clear();

            DataList.Add(new HistoryOSModel { PhoneID = "A", VersionOSID = "1" }); // Default
            DataList.Add(new HistoryOSModel { PhoneID = "B", VersionOSID = "2" }); 
            DataList.Add(new HistoryOSModel { PhoneID = "C", VersionOSID = "3" }); 
            DataList.Add(new HistoryOSModel { PhoneID = "D", VersionOSID = "4" }); 

            return DataList;
        }

    }
}