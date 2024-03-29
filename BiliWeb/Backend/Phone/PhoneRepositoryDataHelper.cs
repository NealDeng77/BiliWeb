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
    public class PhoneRepositoryDataHelper
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile PhoneRepositoryDataHelper instance;
        private static readonly object syncRoot = new Object();

        private PhoneRepositoryDataHelper() { }

        public static PhoneRepositoryDataHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new PhoneRepositoryDataHelper();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The AvatarItem List
        /// </summary>
        private List<PhoneModel> DataList = new List<PhoneModel>();

        /// <summary>
        /// Clear the Data List, and build up a new one
        /// </summary>
        /// <returns></returns>
        public List<PhoneModel> GetDefaultDataSet()
        {
            DataList.Clear();

            // call backend on Clinics so ID's match
            ClinicBackend ClinicData = ClinicBackend.Instance;
            List<ClinicModel> clinics = ClinicData.Index();

            DataList.Add(new PhoneModel { ClinicID = clinics[0].ID,
                DeviceModel = "Samsung 7",
                SerialNumber = "1234abcd",
                ID = "f85345ba-e35c-43c2-8a44-635839d8ecb9",
                TransmitSuccessImage = true,
                TransmitFailImage = true,
                ReadingCaptureCount = 2
            }); // Default, force a guid, and Transfer Images for the Default Phone

            DataList.Add(new PhoneModel { ClinicID = clinics[0].ID,  DeviceModel = "Samsung 8", SerialNumber = "Q24D38HTDEX" }); 
            DataList.Add(new PhoneModel { ClinicID = clinics[0].ID,  DeviceModel = "DROID RAZR M", SerialNumber = "W97A68JGKTS" }); 
            DataList.Add(new PhoneModel { ClinicID = clinics[0].ID,  DeviceModel = "Samsung J7 V", SerialNumber = "H66B49KILQT" }); 

            return DataList;
        }

    }
}