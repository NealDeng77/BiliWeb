using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiliWeb.Models;
using BiliWeb.Backend;

namespace BiliWeb.Backend
{
    public class ExampleBackend
    {
        #region SingletonPattern
        private static volatile ExampleBackend instance;
        private static object syncRoot = new object();

        private ExampleBackend() { }

        public static ExampleBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ExampleBackend();
                    }
                }

                return instance;
            }
        }
        #endregion SingletonPattern

        // Hook up the Repositry
        private static IExampleRepository repository = ExampleRepositoryMock.Instance;

        /// <summary>
        /// Sets the Datasource to be Mock or SQL
        /// </summary>
        /// <param name="dataSourceEnum"></param>
        public static void SetDataSource(DataSourceEnum dataSourceEnum)
        {
            switch (dataSourceEnum)
            {

                case DataSourceEnum.Local:
                case DataSourceEnum.ServerLive:
                case DataSourceEnum.ServerTest:
                    DataSourceBackendTable.Instance.SetDataSourceServerMode(dataSourceEnum);
                    repository = ExampleRepositoryStore.Instance;
                    break;

                case DataSourceEnum.SQL:
                case DataSourceEnum.Mock:
                default:
                    // Default is to use the Mock
                    repository = ExampleRepositoryMock.Instance;
                    break;
            }

        }

        /// <summary>
        /// Switch the data set between Demo, Default and Unit Test
        /// </summary>
        /// <param name="SetEnum"></param>
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
        /// <param name="data"></param>
        /// <returns></returns>
        public ExampleModel Create(ExampleModel data)
        {
            var myData = repository.Create(data);
            return myData;
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ExampleModel Read(string id)
        {
            var myData = repository.Read(id);
            return myData;
        }
        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ExampleModel Update(ExampleModel data)
        {
            var myData = repository.Update(data);
            return myData;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            var myData = repository.Delete(id);
            return myData;
        }

        /// <summary>
        ///  Returns the List of Examples
        /// </summary>
        /// <returns></returns>
        public List<ExampleModel> Index()
        {
            var myData = repository.Index();
            return myData;
        }
    }
}