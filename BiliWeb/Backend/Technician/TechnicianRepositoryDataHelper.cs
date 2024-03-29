﻿using System;
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

            DataList.Add(new TechnicianModel { FirstName = "Mike", LastName = "Smith", DateOfBirth = new System.DateTime(2000, 1, 2), ClinicID = "Test1", ID= "f06e8715-380f-47ef-9ebc-ac5e25c14652" }); // Default, force an ID
            DataList.Add(new TechnicianModel { FirstName = "Doug", LastName = "Smith", DateOfBirth = new System.DateTime(2000, 1, 3), ClinicID = "Test2" }); 
            DataList.Add(new TechnicianModel { FirstName = "Jean", LastName = "Smith", DateOfBirth = new System.DateTime(2000, 1, 4), ClinicID = "Test3" }); 
            DataList.Add(new TechnicianModel { FirstName = "Sue", LastName = "Smith", DateOfBirth = new System.DateTime(2000, 1, 5), ClinicID = "Test4" }); 

            return DataList;
        }

    }
}