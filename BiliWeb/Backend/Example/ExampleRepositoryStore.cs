using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiliWeb.Models;

namespace BiliWeb.Backend
{
    /// <summary>
    /// In Memory Implementation of a Example data store
    /// </summary>
    public class ExampleRepositoryStore : IExampleRepository
    {
        #region Singleton
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile ExampleRepositoryStore instance;
        private static readonly object syncRoot = new Object();

        private ExampleRepositoryStore() { }

        public static ExampleRepositoryStore Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ExampleRepositoryStore();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        private List<ExampleModel> dataset = new List<ExampleModel>();
        private string dataSourceString = "Store";

        public const string ClassName = "ExampleModel";
        
        /// <summary>
        /// Table Name used for data storage
        /// </summary>
        private readonly string tableName = ClassName.ToLower();

        /// <summary>
        /// Partition Key used for data storage
        /// </summary>
        private readonly string partitionKey = ClassName.ToLower();


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
        /// Makes a new AvatarItem
        /// </summary>
        /// <param name="data"></param>
        /// <returns>AvatarItem Passed In</returns>
        public ExampleModel Create(ExampleModel data, DataSourceEnum dataSourceEnum = DataSourceEnum.Unknown)
        {
            dataset.Add(data);

            // Add to Storage
            var myResult = DataSourceBackendTable.Instance.Create<ExampleModel>(tableName, partitionKey, data.ID, data, dataSourceEnum);

            return data;
        }

        /// <summary>
        /// Return the data for the id passed in
        /// Does not access storage, just reads from memeory
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Null or valid data</returns>
        public ExampleModel Read(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var myReturn = dataset.Find(n => n.ID == id);
            return myReturn;
        }

        /// <summary>
        /// Update all attributes to be what is passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Null or updated data</returns>
        public ExampleModel Update(ExampleModel data)
        {
            if (data == null)
            {
                return null;
            }

            var myReturn = Read(data.ID);
            if (myReturn == null)
            {
                return null;
            }

            myReturn.Update(data);

            // Update Storage
            var myResult = DataSourceBackendTable.Instance.Create<ExampleModel>(tableName, partitionKey, data.ID, data);

            return data;
        }

        /// <summary>
        /// Remove the Data item if it is in the list
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True for success, else false</returns>
        public bool Delete(string Id, DataSourceEnum dataSourceEnum = DataSourceEnum.Unknown)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return false;
            }

            // If using the defaul data source, use it, else just do the table operation
            if (dataSourceEnum == DataSourceEnum.Unknown)
            {
                var data = Read(Id);
                if (data == null)
                {
                    return false;
                }

                if (dataset.Remove(data) == false)
                {
                    return false;
                }
            }

            // Storage Delete
            var myReturn = DataSourceBackendTable.Instance.Delete<ExampleModel>(tableName, partitionKey, Id, dataSourceEnum);

            return myReturn;
        }

        /// <summary>
        /// Return the full dataset
        /// </summary>
        /// <returns>List of AvatarItems</returns>
        public List<ExampleModel> Index()
        {
            return dataset;
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
        /// Clears the Data
        /// </summary>
        private void DataSetClear()
        {
            dataset.Clear();
        }

        /// <summary>
        /// The Defalt Data Set
        /// </summary>
        private void DataSetDefault()
        {
            DataSetClear();
            CreateDataSetDefaultData();
        }

        /// <summary>
        /// Load the data from the server, and then default data if needed.
        /// </summary>
        public void CreateDataSetDefaultData()
        {

            // Storage Load all rows
            var DataSetList = LoadAll();

            foreach (var item in DataSetList)
            {
                dataset.Add(item);
            }

            // If Storage is Empty, then Create.
            if (dataset.Count < 1)
            {
                CreateDataSetDefault();
            }

            // Order the set by Date
            dataset = dataset.OrderBy(x => x.Date).ToList();
        }


        /// <summary>
        /// Load all the records from the datasource
        /// </summary>
        /// <param name="dataSourceEnum"></param>
        /// <returns></returns>
        public List<ExampleModel> LoadAll(DataSourceEnum dataSourceEnum = DataSourceEnum.Unknown)
        {
            var DataSetList = DataSourceBackendTable.Instance.LoadAll<ExampleModel>(tableName, partitionKey, true, dataSourceEnum);

            return DataSetList;
        }

        /// <summary>
        /// Get the Default data set, and then add it to the current
        /// </summary>
        private void CreateDataSetDefault()
        {
            var dataSet = ExampleRepositoryDataHelper.Instance.GetDefaultDataSet();
            foreach (var item in dataSet)
            {
                Create(item);
            }
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
        /// Backup the Data from Source to Destination
        /// </summary>
        /// <param name="dataSourceSource"></param>
        /// <param name="dataSourceDestination"></param>
        /// <returns></returns>
        public bool BackupData(DataSourceEnum dataSourceSource, DataSourceEnum dataSourceDestination)
        {
            // Read all the records from the Source using current database defaults

            var DataAllSource = LoadAll(dataSourceSource);
            if (DataAllSource == null || !DataAllSource.Any())
            {
                return false;
            }

            // Empty out Destination Table
            // Get all rows in the destination Table
            // Walk and delete each item, because delete table takes too long...
            var DataAllDestination = LoadAll(dataSourceDestination);
            if (DataAllDestination == null)
            {
                return false;
            }

            foreach (var data in DataAllDestination)
            {
                Delete(data.ID, dataSourceDestination);
            }

            // Write the data to the destination
            foreach (var data in DataAllSource)
            {
                Create(data, dataSourceDestination);
            }

            return true;
        }
    }
}


/*
 * 



/// <summary>
/// Add the Example item to the data store
/// </summary>
/// <param name="data">
/// The new Example item to add to the data store
/// </param>
/// <returns>return the passed in Example item</returns>
public ExampleModel Create(ExampleModel data)
        {
            if (data == null)
            {
                return null;
            }

            dataset.Add(data);
            return data;
        }

        /// <summary>
        /// Return the requested Example item from the data store
        /// if not found, return null
        /// </summary>
        /// <param name="id">the item to find</param>
        /// <returns>the item from the datastore, or null</returns>
        public ExampleModel Read(String id)
        {
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
        public ExampleModel Update(ExampleModel data)
        {
            // Get the first instance of the record
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
        public Boolean Delete(String id)
        {
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
        public List<ExampleModel> Index()
        {
            return dataset;
        }
    }
}
 */
