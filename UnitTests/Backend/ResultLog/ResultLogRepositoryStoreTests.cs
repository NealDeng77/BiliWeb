using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BiliWeb.Models;
using BiliWeb.Controllers;
using BiliWeb.Backend;

namespace UnitTests.Backend
{
    [TestClass]
    public class ResultLogRepositoryStoreTests
    {
        #region IndexTests
        /// <summary>
        /// Ensure the Default Index page on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void ResultLog_Index_Get_Default_Should_Pass()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.ResultLogBackend;

            // Act
            var result = myBackend.Index();

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion IndexTests

        #region CreateTests
        /// <summary>
        /// Ensure the Create Method on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void ResultLog_Create_Default_Should_Pass()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.ResultLogBackend;
            var myData = new ResultLogModel();

            // Act
            var result = myBackend.Create(myData);

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Create with Null should Fail
        /// </summary>
        [TestMethod]
        public void ResultLog_Create_InValid_Null_Should_Fail()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.ResultLogBackend;
            var myData = new ResultLogModel();

            // Act
            var result = myBackend.Create(null);

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.IsNull(result);
        }
        #endregion CreateTests

        #region ReadTests
        /// <summary>
        /// Ensure the Read Method with no data should fail
        /// </summary>
        [TestMethod]
        public void ResultLog_Read_Get_Data_InValid_Null_Should_Fail()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.ResultLogBackend;

            // Act
            var result = myBackend.Read(null);

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Ensure the Read Method with no data should fail
        /// </summary>
        [TestMethod]
        public void ResultLog_Read_Get_Data_InValid_Bogus_Should_Fail()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.ResultLogBackend;

            // Act
            var result = myBackend.Read("bogus");

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.IsNull(result);
        }
        #endregion ReadTests

        #region UpdateTests
        /// <summary>
        /// Ensure the Update Method on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void ResultLog_Update_Default_Should_Pass()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.ResultLogBackend;
            var myData = myBackend.Index().FirstOrDefault();

            // Make a Copy of the Data and update an aspect of it
            var myDataCopy = new ResultLogModel(myData);
            myDataCopy.ID = myData.ID; // Force the ID to match for this test.
            myDataCopy.ClinicID = "New3";

            // Act
            var result = myBackend.Update(myDataCopy);

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.AreEqual("New3", result.ClinicID);

        }

        /// <summary>
        /// Updating a Null record, shoudl Fail
        /// </summary>
        [TestMethod]
        public void ResultLog_Update_InValid_Null_Should_Fail()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.ResultLogBackend;

            // Act
            var result = myBackend.Update(null);

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// Updating a bogus record, should Fail
        /// </summary>
        [TestMethod]
        public void ResultLog_Update_InValid_Bogus_Should_Fail()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.ResultLogBackend;
            var myDataCopy = new ResultLogModel
            {
                ID = "bogus"
            };

            // Act
            var result = myBackend.Update(myDataCopy);

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.AreEqual(null, result);
        }
        #endregion UpdateTests

        #region DeleteTests
        /// <summary>
        /// Ensure the Delete Method with no data should fail
        /// </summary>
        [TestMethod]
        public void ResultLog_Delete_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.ResultLogBackend;

            // Act
            var result = myBackend.Delete(null);

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Ensure the Delete Method with no data should fail
        /// </summary>
        [TestMethod]
        public void ResultLog_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.ResultLogBackend;

            // Act
            var result = myBackend.Delete("bogus");

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion DeleteTests

        #region ResetTests
        /// <summary>
        /// To Test reset
        /// Get the List of Objects
        /// Delete One
        /// Reset
        /// See if it is back
        /// </summary>
        [TestMethod]
        public void ResultLog_Reset_Data_Valid_Should_Pass()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.ResultLogBackend;
            var dataOriginal = myBackend.Index().FirstOrDefault();

            // Act
            myBackend.Delete(dataOriginal.ID);

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.AreEqual(dataOriginal.BilirubinValue, myBackend.Index().FirstOrDefault().BilirubinValue);
        }
        #endregion ResetTests

        #region BackupDataTests
        // Add Later, after Table is working and Moq is enabled
        #endregion BackupDataTests

        #region GetDataSourceStringTests
        /// <summary>
        /// String should Match the Store or Store
        /// </summary>
        [TestMethod]
        public void ResultLog_GetDataSourceString_Data_Valid_Should_Pass()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.ResultLogBackend;

            // Act
            var result = myBackend.GetDataSourceString();

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.AreEqual("Store", result);
        }
        #endregion GetDataSourceStringTests
    }
}
