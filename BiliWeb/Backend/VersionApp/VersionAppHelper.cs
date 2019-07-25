﻿using System.Collections.Generic;
using System.Linq;
using BiliWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiliWeb.Backend
{
    public static class VersionAppHelper
    {
        /// <summary>
        /// Convert the list of data to a Select List
        /// This allows it to be used in a Drop Down List Box
        /// Update Value to be the Value to show in the Box
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> ToSelectListItems(this IEnumerable<VersionAppModel> dataSet, string selectedId)
        {
            return
                dataSet.OrderBy(m => m.ID)
                      .Select(m =>
                          new SelectListItem
                          {
                              Selected = (m.ID == selectedId),
                              Value = m.ID.ToString(),

                              // TODO: Change the item here to the appropriate item to show in the list box
                              Text = m.VersionAppName
                          });
        }

        /// <summary>
        /// Converts the ID for a record, to a string for the item.
        /// For VersionApp converts id 234-asdf-234-sdf to "Bellevue"
        /// </summary>
        /// <param name="id">valid record ID</param>
        /// <returns>empty string for error, else returns the converted field</returns>
        public static string ConvertIDtoString(string id)
        {
            var data = DataSourceBackend.Instance.VersionAppBackend.Read(id);
            if (data == null)
            {
                return string.Empty;
            }

            //  TODO: Change the .Name attribute to the appropriate attribute to return for the conversion.
            return data.VersionAppName;
        }
    }
}