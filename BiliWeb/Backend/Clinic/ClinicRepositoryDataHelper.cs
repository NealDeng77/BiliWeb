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
    public class ClinicRepositoryDataHelper
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile ClinicRepositoryDataHelper instance;
        private static readonly object syncRoot = new Object();

        private ClinicRepositoryDataHelper() { }

        public static ClinicRepositoryDataHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ClinicRepositoryDataHelper();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The AvatarItem List
        /// </summary>
        private List<ClinicModel> DataList = new List<ClinicModel>();

        /// <summary>
        /// Clear the Data List, and build up a new one
        /// </summary>
        /// <returns></returns>
        public List<ClinicModel> GetDefaultDataSet()
        {
            DataList.Clear();

            DataList.Add(new ClinicModel { Name = "Mike" }); // Default
            DataList.Add(new ClinicModel { Name = "Doug" }); 
            DataList.Add(new ClinicModel { Name = "Jea" }); 
            DataList.Add(new ClinicModel { Name = "Sue" }); 

            return DataList;
        }

    }
}