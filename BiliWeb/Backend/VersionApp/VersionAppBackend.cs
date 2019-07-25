using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiliWeb.Models;
using BiliWeb.Backend;

namespace BiliWeb.Backend
{
    public class VersionAppBackend
    {
        #region SingletonPattern
        private static volatile VersionAppBackend instance;
        private static object syncRoot = new object();

        private VersionAppBackend() { }

        public static VersionAppBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new VersionAppBackend();
                    }
                }

                return instance;
            }
        }
        #endregion SingletonPattern

        // Hook up the Repositry
        private static IVersionAppRepository repository = VersionAppRepositoryMock.Instance;

        /// <summary>
        /// Sets the Datasource to be Mock or SQL
        /// </summary>
        /// <param name="dataSourceEnum">The mock status.</param>
        public static void SetDataSource(DataSourceEnum dataSourceEnum)
        {
            switch (dataSourceEnum)
            {
                /* 
                 * These will all use a Table store as the backend.
                 * Local is used when running azure local service
                 * Live and Test point to azure instances
                 */
                case DataSourceEnum.Local:
                case DataSourceEnum.ServerLive:
                case DataSourceEnum.ServerTest:
                    DataSourceBackendTable.Instance.SetDataSourceServerMode(dataSourceEnum);
                    repository = VersionAppRepositoryStore.Instance;
                    break;

                case DataSourceEnum.SQL:    // Same as Mock because no sql backend for this version.
                case DataSourceEnum.Mock:
                default:
                    // Default is to use the Mock
                    repository = VersionAppRepositoryMock.Instance;
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
        public VersionAppModel Create(VersionAppModel data)
        {
            var myData = repository.Create(data);
            return myData;
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="id">The id of a record.</param>
        /// <returns>The record associated with the id.</returns>
        public VersionAppModel Read(string id)
        {
            var myData = repository.Read(id);
            return myData;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="data">The record passed in.</param>
        /// <returns>The updated record.</returns>
        public VersionAppModel Update(VersionAppModel data)
        {
            var myData = repository.Update(data);
            return myData;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">The id of a record.</param>
        /// <returns>True if the record was deleted, false otherwise.</returns>
        public bool Delete(string id)
        {
            var myData = repository.Delete(id);
            return myData;
        }

        /// <summary>
        ///  Returns the List of VersionApps
        /// </summary>
        /// <returns>The list of VersionApps.</returns>
        public List<VersionAppModel> Index()
        {
            var myData = repository.Index();
            return myData;
        }
    }
}