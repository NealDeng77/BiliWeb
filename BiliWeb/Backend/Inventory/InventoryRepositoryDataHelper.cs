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


            //Call backend clinic so ids match
            ClinicBackend ClinicData = ClinicBackend.Instance;
            List<ClinicModel> clinics = ClinicData.Index();

            DataList.Add(new InventoryModel { ClinicID = clinics[0].ID,  TestStripStock = 30 }); // Default
            DataList.Add(new InventoryModel { ClinicID = clinics[1].ID,  TestStripStock = 20 }); 
            DataList.Add(new InventoryModel { ClinicID = clinics[2].ID,  TestStripStock = 15 }); 
            //DataList.Add(new InventoryModel { ClinicID = clinics[3].ID,  TestStripStock = 50 }); 

            return DataList;
        }

    }
}