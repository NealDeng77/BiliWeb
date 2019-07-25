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
    public class PhotoRepositoryDataHelper
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile PhotoRepositoryDataHelper instance;
        private static readonly object syncRoot = new Object();

        private PhotoRepositoryDataHelper() { }

        public static PhotoRepositoryDataHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new PhotoRepositoryDataHelper();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The AvatarItem List
        /// </summary>
        private List<PhotoModel> DataList = new List<PhotoModel>();

        /// <summary>
        /// Clear the Data List, and build up a new one
        /// </summary>
        /// <returns></returns>
        public List<PhotoModel> GetDefaultDataSet()
        {
            DataList.Clear();

            DataList.Add(new PhotoModel { Note = "Mike's Photo" }); // Default
            DataList.Add(new PhotoModel { Note = "Doug's Photo" }); 
            DataList.Add(new PhotoModel { Note = "Jea's Photo" }); 
            DataList.Add(new PhotoModel { Note = "Sue's Photo" }); 

            return DataList;
        }

    }
}