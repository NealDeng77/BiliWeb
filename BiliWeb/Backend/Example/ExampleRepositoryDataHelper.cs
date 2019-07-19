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
    public class ExampleRepositoryDataHelper
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile ExampleRepositoryDataHelper instance;
        private static readonly object syncRoot = new Object();

        private ExampleRepositoryDataHelper() { }

        public static ExampleRepositoryDataHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ExampleRepositoryDataHelper();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The AvatarItem List
        /// </summary>
        private List<ExampleModel> DataList = new List<ExampleModel>();

        /// <summary>
        /// Clear the Data List, and build up a new one
        /// </summary>
        /// <returns></returns>
        public List<ExampleModel> GetDefaultDataSet()
        {
            DataList.Clear();

            DataList.Add(new ExampleModel { Name = "Mike" }); // Default
            DataList.Add(new ExampleModel { Name = "Doug" }); 
            DataList.Add(new ExampleModel { Name = "Jea" }); 
            DataList.Add(new ExampleModel { Name = "Sue" }); 

            return DataList;
        }

    }
}