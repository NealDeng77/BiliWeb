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
    public class TechnicianRepositoryDataHelper
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile TechnicianRepositoryDataHelper instance;
        private static readonly object syncRoot = new Object();

        private TechnicianRepositoryDataHelper() { }

        public static TechnicianRepositoryDataHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new TechnicianRepositoryDataHelper();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The AvatarItem List
        /// </summary>
        private List<TechnicianModel> DataList = new List<TechnicianModel>();

        /// <summary>
        /// Clear the Data List, and build up a new one
        /// </summary>
        /// <returns></returns>
        public List<TechnicianModel> GetDefaultDataSet()
        {
            DataList.Clear();

            DataList.Add(new TechnicianModel { Name = "Mike" }); // Default
            DataList.Add(new TechnicianModel { Name = "Doug" }); 
            DataList.Add(new TechnicianModel { Name = "Jea" }); 
            DataList.Add(new TechnicianModel { Name = "Sue" }); 

            return DataList;
        }

    }
}