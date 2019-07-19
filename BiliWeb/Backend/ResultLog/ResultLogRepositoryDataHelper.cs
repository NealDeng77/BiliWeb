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
    public class ResultLogRepositoryDataHelper
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile ResultLogRepositoryDataHelper instance;
        private static readonly object syncRoot = new Object();

        private ResultLogRepositoryDataHelper() { }

        public static ResultLogRepositoryDataHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ResultLogRepositoryDataHelper();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The AvatarItem List
        /// </summary>
        private List<ResultLogModel> DataList = new List<ResultLogModel>();

        /// <summary>
        /// Clear the Data List, and build up a new one
        /// </summary>
        /// <returns></returns>
        public List<ResultLogModel> GetDefaultDataSet()
        {
            DataList.Clear();

            DataList.Add(new ResultLogModel { Name = "Mike", BilirubinValue=1 }); // Default
            DataList.Add(new ResultLogModel { Name = "Doug", BilirubinValue = 2 }); 
            DataList.Add(new ResultLogModel { Name = "Jea", BilirubinValue = 3.5 }); 
            DataList.Add(new ResultLogModel { Name = "Sue", BilirubinValue = 10 }); 

            return DataList;
        }

    }
}