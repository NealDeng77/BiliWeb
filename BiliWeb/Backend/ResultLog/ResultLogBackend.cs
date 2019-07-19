using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiliWeb.Models;
using BiliWeb.Backend;

namespace BiliWeb.Backend
{
    public class ResultLogBackend
    {
        #region SingletonPattern
        private static volatile ResultLogBackend instance;
        private static object syncRoot = new object();

        private ResultLogBackend() { }

        public static ResultLogBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ResultLogBackend();
                    }
                }

                return instance;
            }
        }
        #endregion SingletonPattern

        // Hook up the Repositry
        private static IResultLogRepository repository = ResultLogRepositoryMock.Instance;

        /// <summary>
        /// Sets the Datasource to be Mock or SQL
        /// </summary>
        /// <param name="dataSourceEnum">The mock status.</param>
        public static void SetDataSource(DataSourceEnum dataSourceEnum)
        {
            switch (dataSourceEnum)
            {

                case DataSourceEnum.Local:
                case DataSourceEnum.ServerLive:
                case DataSourceEnum.ServerTest:
                    DataSourceBackendTable.Instance.SetDataSourceServerMode(dataSourceEnum);
                    repository = ResultLogRepositoryStore.Instance;
                    break;

                case DataSourceEnum.SQL:
                case DataSourceEnum.Mock:
                default:
                    // Default is to use the Mock
                    repository = ResultLogRepositoryMock.Instance;
                    break;
            }

        }

        /// <summary>
        /// Switch the data set between Demo, Default and Unit Test
        /// </summary>
        /// <param name="SetEnum">The type of data running.</param>
        public static void SetDataSourceDataSet(DataSourceDataSetEnum SetEnum)
        {
            repository.LoadDataSet(SetEnum);
        }

        /// <summary>
        /// Helper function that resets the DataSource, and rereads it.
        /// </summary>
        public void Reset()
        {
            repository.Reset();
        }

        /// <summary>
        /// Helper function that resets the DataSource String, is it Mock or Store
        /// </summary>
        public string GetDataSourceString()
        {
            var data = repository.GetDataSourceString();
            return data;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="data">The record passed in.</param>
        /// <returns>The record created for the result.</returns>
        public ResultLogModel Create(ResultLogModel data)
        {
            var myData = repository.Create(data);
            return myData;
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="id">The result id of a test.</param>
        /// <returns>The record for the result.</returns>
        public ResultLogModel Read(string id)
        {
            var myData = repository.Read(id);
            return myData;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="data">The record passed in.</param>
        /// <returns>The updated record.</returns>
        public ResultLogModel Update(ResultLogModel data)
        {
            var myData = repository.Update(data);
            return myData;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">The result id of a test.</param>
        /// <returns>True if the record was deleted, false otherwise.</returns>
        public bool Delete(string id)
        {
            var myData = repository.Delete(id);
            return myData;
        }

        /// <summary>
        ///  Returns the List of ResultLogs
        /// </summary>
        /// <returns>The list of result logs.</returns>
        public List<ResultLogModel> Index()
        {
            var myData = repository.Index();
            return myData;
        }
    }
}