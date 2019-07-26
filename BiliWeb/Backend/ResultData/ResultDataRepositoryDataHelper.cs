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
    public class ResultDataRepositoryDataHelper
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile ResultDataRepositoryDataHelper instance;
        private static readonly object syncRoot = new Object();

        private ResultDataRepositoryDataHelper() { }

        public static ResultDataRepositoryDataHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ResultDataRepositoryDataHelper();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The AvatarItem List
        /// </summary>
        private List<ResultDataModel> DataList = new List<ResultDataModel>();

        /// <summary>
        /// Clear the Data List, and build up a new one
        /// </summary>
        /// <returns></returns>
        public List<ResultDataModel> GetDefaultDataSet()
        {
            DataList.Clear();

            DataList.Add(new ResultDataModel { LabResult = 0 }); // Default
            DataList.Add(new ResultDataModel { LabResult = 10 }); 
            DataList.Add(new ResultDataModel { LabResult = 12.5 }); 
            DataList.Add(new ResultDataModel { LabResult = 15 }); 

            return DataList;
        }

    }
}