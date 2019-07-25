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

            DataList.Add(new ClinicModel { Name = "Asaba Federal Hospital", Address = "Nnebisi Road", City = "Isieke, Asaba", Country = "Nigeria", Contact = "John Appleseed", Phone = "+234 701 918 8232", Email = "m.me/fmcasaba", Notes = "No Email provided" }); // Default
            DataList.Add(new ClinicModel { Name = "Dept. of Pediatrics, University of Jos", Address = "Bauchi Rd.", City = "Jos", Country = "Nigeria", Contact = "Jane Doe", Phone = "", Email = "onlinecommunications@unijos.edu.ng", Notes = "No Phone # provided" }); // Default
            DataList.Add(new ClinicModel { Name = "Dept. of Pediatrics, Bayero University", Address = "Gwarzo Rd.", City = "Kano", Country = "Nigeria", Contact = "", Phone = "+234 64 666 023", Email = "vc@buk.edu.ng", Notes = "" }); // Default
            DataList.Add(new ClinicModel { Name = "Dept. of Pediatrics, Ahmadu Bello University", Address = "Community Market", City = "Zaria", Country = "Nigeria", Contact = "", Phone = "+234 09076797748", Email = "uhs@abu.edu.edu", Notes = "" }); // Default
            DataList.Add(new ClinicModel { Name = "Dept. of Pediatrics, Cairo University", Address = "Al Kasr Al Aini, قصر العينى،", City = "Al Manial", Country = "Egypt", Contact = "", Phone = "+20 2 23641088", Email = "SA@kasralainy.edu.eg", Notes = "" }); // Default

            return DataList;
        }

    }
}