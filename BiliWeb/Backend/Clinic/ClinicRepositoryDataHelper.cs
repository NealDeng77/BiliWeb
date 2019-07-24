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

            DataList.Add(new ClinicModel { Name = "Bellevue Hospital", Address = "13 Bellevue Dr.", City = "Bellevue", Country = "USA", Contact = "John Appleseed", Phone = "+14254254252", Email = "jappleseed@gmail.com", Notes = "Newly opened clinic" }); // Default
            DataList.Add(new ClinicModel { Name = "Seattle Hospital", Address = "31 Cherry St.", City = "Seattle", Country = "USA", Contact = "Jane Doe", Phone = "+12062062060", Email = "jdoe@gmail.com", Notes = "Currently closed for the maintenance" }); // Default
            DataList.Add(new ClinicModel { Name = "Kano State Hospital", Address = "800 Terrace St.", City = "Seattle", Country = "USA", Contact = "Chicago East", Phone = "+12063837888", Email = "keast@outlook.com", Notes = "" }); // Default
            DataList.Add(new ClinicModel { Name = "Ijora Clinic", Address = "4225 11th Ave.", City = "Renton", Country = "USA", Contact = "Keith Suth", Phone = "+12531114444", Email = "ksuth@yahoo.com", Notes = "" }); // Default

            return DataList;
        }

    }
}