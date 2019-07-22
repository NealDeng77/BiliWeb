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
    public class InventoryRepositoryDataHelper
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile InventoryRepositoryDataHelper instance;
        private static readonly object syncRoot = new Object();

        private InventoryRepositoryDataHelper() { }

        public static InventoryRepositoryDataHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new InventoryRepositoryDataHelper();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The AvatarItem List
        /// </summary>
        private List<InventoryModel> DataList = new List<InventoryModel>();

        /// <summary>
        /// Clear the Data List, and build up a new one
        /// </summary>
        /// <returns></returns>
        public List<InventoryModel> GetDefaultDataSet()
        {
            DataList.Clear();

            DataList.Add(new InventoryModel { ClinicID = "KanoState00", TestStripStock = 30 }); // Default
            DataList.Add(new InventoryModel { ClinicID = "Ijowa18", TestStripStock = 20 }); 
            DataList.Add(new InventoryModel { ClinicID = "Bellvue16", TestStripStock = 15 }); 
            DataList.Add(new InventoryModel { ClinicID = "Seattle01", TestStripStock = 50 }); 

            return DataList;
        }

    }
}