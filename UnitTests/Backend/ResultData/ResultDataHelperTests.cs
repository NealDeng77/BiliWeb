using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Backend;
using System.Linq;

namespace UnitTests.Backend
{
    [TestClass]
    public class ResultDataHelperTests
    {

        #region ConvertIDtoStringTests
        /// <summary>
        /// Convert Valid ID to Value
        /// </summary>
        [TestMethod]
        public void ResultDataHelper_ConvertIDtoString_Valid_Should_Pass()
        {
            // Arrange
            var data = new ResultDataModel
            {
                Name = "Name"
            };
            DataSourceBackend.Instance.ResultDataBackend.Create(data);

            // Act
            var result = ResultDataHelper.ConvertIDtoString(data.ID);

            // Reset
            DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual("Name", result);
        }

        /// <summary>
        /// Convert with Null should Fail
        /// </summary>
        [TestMethod]
        public void ResultDataHelper_ConvertIDtoString_InValid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = ResultDataHelper.ConvertIDtoString(null);

            // Reset

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        /// <summary>
        /// Convert with Null should Fail
        /// </summary>
        [TestMethod]
        public void ResultDataHelper_ConvertIDtoString_InValid_Bogus_Should_Fail()
        {
            // Arrange

            // Act
            var result = ResultDataHelper.ConvertIDtoString("bogus");

            // Reset

            // Assert
            Assert.AreEqual(string.Empty, result);
        }
        #endregion ConvertIDtoStringTests    

        #region ToSelectListItemsTests
        /// <summary>
        /// Returns a set of Select List Items from the data set of ResultData
        /// Used for converting the records to a list that can go into a drop down list box
        /// </summary>
        [TestMethod]
        public void ResultDataHelper_ToSelectListItemsTests_Valid_Should_Pass()
        {
            // Arrange
            var data = DataSourceBackend.Instance.ResultDataBackend.Index();

            // Act
            var result = ResultDataHelper.ToSelectListItems(data,null);

            // Reset

            // Assert
            // Check each item returned, and make sure it matches the original data
            foreach (var item in result)
            {
                Assert.AreEqual(item.Text, data.Find(m=>m.ID==item.Value).Name);
            }

        }

        /// <summary>
        /// Returns a set of Select List Items from the data set of ResultData
        /// Make sure the Selected Value is returned
        /// </summary>
        [TestMethod]
        public void ResultDataHelper_ToSelectListItemsTests_Valid_Selected_Should_Pass()
        {
            // Arrange
            var data = DataSourceBackend.Instance.ResultDataBackend.Index();

            // Choose item to be selected
            var value = data[0].ID;

            // Act
            var result = ResultDataHelper.ToSelectListItems(data, value);

            // Reset

            // Assert
            // The First should be the seleted item.
            Assert.AreEqual(result.First(m => m.Selected == true).Value, data.Find(m => m.ID == value).ID);
            // Only One should be Selected
            Assert.AreEqual(1, result.Where(m => m.Selected == true).Count());

        }

        /// <summary>
        /// Returns a set of Select List Items from the data set of ResultData
        /// If the Selected item is not in the list, return the list with no selected items
        /// </summary>
        [TestMethod]
        public void ResultDataHelper_ToSelectListItemsTests_InValid_Selected_Should_Pass()
        {
            // Arrange
            var data = DataSourceBackend.Instance.ResultDataBackend.Index();

            // Choose item to be selected
            var value = "bogus";

            // Act
            var result = ResultDataHelper.ToSelectListItems(data, value);
            var resultCount = result.Where(m => m.Selected == true).Count();

            // Reset

            // Assert
            Assert.AreEqual(0, resultCount);
        }
        #endregion ToSelectListItemsTests
    }
}
