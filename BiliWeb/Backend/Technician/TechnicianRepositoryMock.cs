using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiliWeb.Models;

namespace BiliWeb.Backend
{
    /// <summary>
    /// In Memory Implementation of a Technician data store
    /// </summary>
    public class TechnicianRepositoryMock : ITechnicianRepository
    {
        #region Singleton
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile TechnicianRepositoryMock instance;
        private static readonly object syncRoot = new Object();

        private TechnicianRepositoryMock() { }

        public static TechnicianRepositoryMock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new TechnicianRepositoryMock();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }
        #endregion Singleton

        private List<TechnicianModel> dataset = new List<TechnicianModel>();
        private string dataSourceString = "Mock";
        
        /// <summary>
        /// Clears the Data
        /// </summary>
        private void DataSetClear()
        {
            dataset.Clear();
        }

        /// <summary>
        /// The Data Source String
        /// Mock or Store
        /// </summary>
        /// <returns></returns>
        public string GetDataSourceString()
        {
            return dataSourceString;
        }

        /// <summary>
        /// The Defalt Data Set
        /// </summary>
        private void DataSetDefault()
        {
            DataSetClear();

            var dataSet = TechnicianRepositoryDataHelper.Instance.GetDefaultDataSet();
            foreach (var item in dataSet)
            {
                Create(item);
            }

            // Order the set by TimeStamp
            dataset = dataset.OrderBy(x => x.Date).ToList();
        }

        /// <summary>
        /// Data set for demo
        /// </summary>
        private void DataSetDemo()
        {
            DataSetDefault();
        }

        /// <summary>
        /// Unit Test data set
        /// </summary>
        private void DataSetUnitTest()
        {
            DataSetDefault();
        }

        /// <summary>
        /// Set which data to load
        /// </summary>
        /// <param name="setEnum"></param>
        public void LoadDataSet(DataSourceDataSetEnum setEnum)
        {
            switch (setEnum)
            {
                case DataSourceDataSetEnum.Demo:
                    DataSetDemo();
                    break;

                case DataSourceDataSetEnum.UnitTest:
                    DataSetUnitTest();
                    break;

                case DataSourceDataSetEnum.Default:
                default:
                    DataSetDefault();
                    break;
            }
        }

        /// <summary>
        /// Not implemented for Mock
        /// </summary>
        /// <param name="dataSourceSource"></param>
        /// <param name="dataSourceDestination"></param>
        /// <returns></returns>
        public bool BackupData(DataSourceEnum dataSourceSource, DataSourceEnum dataSourceDestination)
        {
            return true;
        }

        /// <summary>
        /// Reset the Data, and reload it
        /// </summary>
        public void Reset()
        {
            Initialize();
        }

        /// <summary>
        /// Create Placeholder Initial Data
        /// </summary>
        public void Initialize()
        {
            LoadDataSet(DataSourceDataSetEnum.Default);
        }

        /// <summary>
        /// Add the Technician item to the data store
        /// </summary>
        /// <param name="data">
        /// The new Technician item to add to the data store
        /// </param>
        /// <returns>return the passed in Technician item</returns>
        public TechnicianModel Create(TechnicianModel data, DataSourceEnum dataSourceEnum = DataSourceEnum.Unknown)
        {
            if (data == null)
            {
                return null;
            }

            dataset.Add(data);
            return data;
        }

        /// <summary>
        /// Return the requested Technician item from the data store
        /// if not found, return null
        /// </summary>
        /// <param name="id">the item to find</param>
        /// <returns>the item from the datastore, or null</returns>
        public TechnicianModel Read(String id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            // Get the first instance of the record
            var myData = dataset.FirstOrDefault(m => m.ID == id);
            if (myData == null)
            {
                return null;
            }

            // Found what was looking for, so all OK
            return myData;
        }

        /// <summary>
        /// Update the item in the data store
        /// use the ID from the item passed in to find the item and then update it
        /// </summary>
        /// <param name="data">the item to update</param>
        /// <returns>the updated item</returns>
        public TechnicianModel Update(TechnicianModel data)
        {
            // Get the first instance of the record

            if (data == null)
            {
                return null;
            }

            var myData = Read(data.ID);
            if (myData == null)
            {
                return null;
            }

            myData.Update(data);
            return data;
        }

        /// <summary>
        /// Remove the item from the data store
        /// Look it up by ID, if found, remove it, and return true
        /// else return false
        /// </summary>
        /// <param name="id">the item to remove by ID</param>
        /// <returns>true if removed</returns>
        public Boolean Delete(String id, DataSourceEnum dataSourceEnum = DataSourceEnum.Unknown)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            // Get the first instance of the record
            var myData = Read(id);
            if (myData == null)
            {
                return false;
            }

            var myResult = dataset.Remove(myData);
            return myResult;
        }

        /// <summary>
        /// Return all items in the data store
        /// </summary>
        /// <returns>a list of all the items in the data store</returns>
        public List<TechnicianModel> Index()
        {
            return dataset;
        }
    }
}