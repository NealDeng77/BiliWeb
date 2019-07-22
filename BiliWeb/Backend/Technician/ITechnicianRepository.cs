using System;
using System.Collections.Generic;
using BiliWeb.Models;

namespace BiliWeb.Backend
{
    /// <summary>
    /// Define an interface which contains the methods for the Technician repository.
    /// All CRUDi aspects
    /// 
    /// </summary>
    public interface ITechnicianRepository
    {
        // Adds a new record to the data source
        TechnicianModel Create(TechnicianModel data, DataSourceEnum dataSourceEnum = DataSourceEnum.Unknown);

        // Returns the record of the matching ID or null if not found
        TechnicianModel Read(String id);

        // Update the record passed in,  the ID and Date are not modified
        TechnicianModel Update(TechnicianModel data);

        // Delete the record with the id passed in, datasource is used for Store calls
        Boolean Delete(String id, DataSourceEnum dataSourceEnum = DataSourceEnum.Unknown);

        // Return all items
        List<TechnicianModel> Index();

        /// Reset, clears the current data and loads fresh
        void Reset();

        /// LoadDataSet specifies which data to load
        void LoadDataSet(DataSourceDataSetEnum setEnum);

        // BakcupData copies data from one source to another
        bool BackupData(DataSourceEnum dataSourceSource, DataSourceEnum dataSourceDestination);

        // GetDataSourceString returns the repository type name, either Mock, or Store
        string GetDataSourceString();
    }
}