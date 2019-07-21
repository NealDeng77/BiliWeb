using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Backend;
using System.Linq;

namespace UnitTests.Backend
{
    [TestClass]
    public class PhoneHelperTests
    {

        #region ConvertIDtoStringTests
        /// <summary>
        /// Convert Valid ID to Value
        /// </summary>
        [TestMethod]
        public void PhoneHelper_ConvertIDtoString_Valid_Should_Pass()
        {
            // Arrange
            var data = new PhoneModel
            {
                DeviceModel = "Device"
            };
            DataSourceBackend.Instance.PhoneBackend.Create(data);

            // Act
            var result = PhoneHelper.ConvertIDtoString(data.ID);

            // Reset
            DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual("Device", result);
        }

        /// <summary>
        /// Convert with Null should Fail
        /// </summary>
        [TestMethod]
        public void PhoneHelper_ConvertIDtoString_InValid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = PhoneHelper.ConvertIDtoString(null);

            // Reset

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        /// <summary>
        /// Convert with Null should Fail
        /// </summary>
        [TestMethod]
        public void PhoneHelper_ConvertIDtoString_InValid_Bogus_Should_Fail()
        {
            // Arrange

            // Act
            var result = PhoneHelper.ConvertIDtoString("bogus");

            // Reset

            // Assert
            Assert.AreEqual(string.Empty, result);
        }
        #endregion ConvertIDtoStringTests    

        #region ToSelectListItemsTests
        /// <summary>
        /// Returns a set of Select List Items from the data set of Example
        /// Used for converting the records to a list that can go into a drop down list box
        /// </summary>
        [TestMethod]
        public void PhoneHelper_ToSelectListItemsTests_Valid_Should_Pass()
        {
            // Arrange
            var data = DataSourceBackend.Instance.PhoneBackend.Index();

            // Act
            var result = PhoneHelper.ToSelectListItems(data,null);

            // Reset

            // Assert
            // Check each item returned, and make sure it matches the original data
            foreach (var item in result)
            {
                Assert.AreEqual(item.Text, data.Find(m=>m.ID==item.Value).DeviceModel);
            }

        }

        /// <summary>
        /// Returns a set of Select List Items from the data set of Example
        /// Make sure the Selected Value is returned
        /// </summary>
        [TestMethod]
        public void PhoneHelper_ToSelectListItemsTests_Valid_Selected_Should_Pass()
        {
            // Arrange
            var data = DataSourceBackend.Instance.PhoneBackend.Index();

            // Choose item to be selected
            var value = data[0].ID;

            // Act
            var result = PhoneHelper.ToSelectListItems(data, value);

            // Reset

            // Assert
            // The First should be the seleted item.
            Assert.AreEqual(result.First(m => m.Selected == true).Value, data.Find(m => m.ID == value).ID);
            // Only One should be Selected
            Assert.AreEqual(1, result.Where(m => m.Selected == true).Count());

        }

        /// <summary>
        /// Returns a set of Select List Items from the data set of Example
        /// If the Selected item is not in the list, return the list with no selected items
        /// </summary>
        [TestMethod]
        public void PhoneHelper_ToSelectListItemsTests_InValid_Selected_Should_Pass()
        {
            // Arrange
            var data = DataSourceBackend.Instance.PhoneBackend.Index();

            // Choose item to be selected
            var value = "bogus";

            // Act
            var result = PhoneHelper.ToSelectListItems(data, value);
            var resultCount = result.Where(m => m.Selected == true).Count();

            // Reset

            // Assert
            Assert.AreEqual(0, resultCount);
        }
        #endregion ToSelectListItemsTests
    }
}
