using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BiliWeb.Models;

namespace BiliWeb.Backend
{

    /// <summary>
    /// Define an interface which contains the methods for the Example repository.
    /// All CRUDi aspects
    /// </summary>
    public interface IExampleRepository
    {
        ExampleModel Create(ExampleModel data, DataSourceEnum dataSourceEnum = DataSourceEnum.Unknown);
        ExampleModel Read(String id);
        ExampleModel Update(ExampleModel data);
        Boolean Delete(String id, DataSourceEnum dataSourceEnum = DataSourceEnum.Unknown);
        List<ExampleModel> Index();

        void Reset();
        void LoadDataSet(DataSourceDataSetEnum setEnum);
        bool BackupData(DataSourceEnum dataSourceSource, DataSourceEnum dataSourceDestination);
        string GetDataSourceString();

    }
}