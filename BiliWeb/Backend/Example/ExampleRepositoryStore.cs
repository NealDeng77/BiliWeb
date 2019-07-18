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
        public List<ExampleModel> dataset = new List<ExampleModel>();

        /// <summary>
        /// Constructor for Example Repository
        /// </summary>
        public ExampleRepositoryStore()
        {
            // Call for Sead data to be created
            Initialize();
        }

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

        /// <summary>
        /// Sets Initial Seed Data
        /// </summary>
        public void Initialize()
        {
            dataset.Add(new ExampleModel { Name = "Mike" });
            dataset.Add(new ExampleModel { Name = "Doug" });
            dataset.Add(new ExampleModel { Name = "Jea" });
            dataset.Add(new ExampleModel { Name = "Sue" });
        }
    }
}