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

            DataList.Add(new ClinicModel { Name = "Asaba Federal Hospital", Address = "Nnebisi Road", City = "Isieke, Asaba", Country = "Nigeria", Contact = "John Appleseed", Phone = "+234 701 918 8232", Email = "m.me/fmcasaba", WhatsApp = "", Notes = "No Email provided", Latitude = "6.2117902", Longitude = "6.7115102", ID = "7ad4cb34-8045-4835-8125-ce8fd0f19cb2" }); // Default, force an ID
            DataList.Add(new ClinicModel { Name = "Dept. of Pediatrics, University of Jos", Address = "Bauchi Rd.", City = "Jos", Country = "Nigeria", Contact = "Jane Doe", Phone = "", Email = "onlinecommunications@unijos.edu.ng", WhatsApp = "", Notes = "No Phone # provided", Latitude = "9.948661", Longitude = "8.891013", }); 
            DataList.Add(new ClinicModel { Name = "Dept. of Pediatrics, Bayero University", Address = "Gwarzo Rd.", City = "Kano", Country = "Nigeria", Contact = "", Phone = "+234 64 666 023", Email = "vc@buk.edu.ng", WhatsApp = "", Notes = "", Latitude = "11.980920", Longitude = "8.482890", }); 
            DataList.Add(new ClinicModel { Name = "Dept. of Pediatrics, Ahmadu Bello University", Address = "Community Market", City = "Zaria", Country = "Nigeria", Contact = "", Phone = "+234 09076797748", Email = "uhs@abu.edu.edu", WhatsApp = "", Notes = "", Latitude = "11.151180", Longitude = "7.654530", }); 
            DataList.Add(new ClinicModel { Name = "Dept. of Pediatrics, Cairo University", Address = "Al Kasr Al Aini, قصر العينى،", City = "Al Manial", Country = "Egypt", Contact = "", Phone = "+20 2 23641088", Email = "SA@kasralainy.edu.eg", WhatsApp = "", Notes = "", Latitude = "30.030908", Longitude = "31.227462", }); 

            return DataList;
        }

    }
}