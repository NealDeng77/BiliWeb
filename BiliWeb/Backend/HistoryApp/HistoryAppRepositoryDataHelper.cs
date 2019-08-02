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

            // get list of phones
            PhoneBackend PhoneBackend = PhoneBackend.Instance;
            List<PhoneModel> PhoneList = PhoneBackend.Index();

            // get list of app versions 
            VersionAppBackend VersionAppBackend = VersionAppBackend.Instance;
            List<VersionAppModel> VersionAppList = VersionAppBackend.Index(); 

            // phone 0
            DataList.Add(new HistoryAppModel { PhoneID = PhoneList[0].ID, VersionAppID = VersionAppList[0].ID, ID = "1cfe60ec-a6b2-4721-9fd6-978aa7bc0882" }); // Default
            DataList.Add(new HistoryAppModel { PhoneID = PhoneList[0].ID, VersionAppID = VersionAppList[1].ID }); 
            DataList.Add(new HistoryAppModel { PhoneID = PhoneList[0].ID, VersionAppID = VersionAppList[2].ID }); 
            DataList.Add(new HistoryAppModel { PhoneID = PhoneList[0].ID, VersionAppID = VersionAppList[3].ID });

            return DataList;
        }

    }
}