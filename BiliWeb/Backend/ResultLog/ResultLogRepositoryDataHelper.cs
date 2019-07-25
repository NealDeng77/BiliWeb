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
            //Call backend clinic so ids match
            ClinicBackend ClinicData = ClinicBackend.Instance;
            List<ClinicModel>  clinics = ClinicData.Index();

            //Call backend phones
            PhoneBackend PhoneData = PhoneBackend.Instance;
            List<PhoneModel> phones = PhoneData.Index();

            //Call backend to technicians
            TechnicianBackend TechnicianData = TechnicianBackend.Instance;
            List<TechnicianModel> tech = TechnicianData.Index();
            
            DataList.Add(new ResultLogModel { ClinicID = clinics[0].ID, PhoneID = phones[0].ID, UserID = tech[0].ID, BilirubinValue = 20 }); // Default
            DataList.Add(new ResultLogModel { ClinicID = clinics[1].ID, PhoneID = phones[1].ID, UserID = tech[1].ID, BilirubinValue = 2 });
            DataList.Add(new ResultLogModel { ClinicID = clinics[2].ID, PhoneID = phones[2].ID, UserID = tech[2].ID, BilirubinValue = 3.5 });
            //DataList.Add(new ResultLogModel { ClinicID = clinics[3].ID, PhoneID = phones[3].ID, UserID = tech[3].ID, BilirubinValue = 10 });
            

            return DataList;
        }

    }
}