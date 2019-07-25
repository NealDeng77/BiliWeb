using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BiliWeb.Models;
using BiliWeb.Controllers;
using BiliWeb.Backend;

namespace UnitTests.Backend
{
    [TestClass]
    public class PhotoRepositoryMockTests
    {
        #region IndexTests
        /// <summary>
        /// Ensure the Default Index page on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Photo_Index_Get_Default_Should_Pass()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;

            // Act
            var result = myBackend.Index();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion IndexTests

        #region CreateTests
        /// <summary>
        /// Ensure the Create Method on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Photo_Create_Default_Should_Pass()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;
            var myData = new PhotoModel();

            // Act
            var result = myBackend.Create(myData);

            // Reset
            myBackend.Reset();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Create with Null should Fail
        /// </summary>
        [TestMethod]
        public void Photo_Create_InValid_Null_Should_Fail()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;
            var myData = new PhotoModel();

            // Act
            var result = myBackend.Create(null);

            // Reset
            myBackend.Reset();

            // Assert
            Assert.IsNull(result);
        }
        #endregion CreateTests

        #region ReadTests
        /// <summary>
        /// Ensure the Read Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Photo_Read_Get_Data_InValid_Null_Should_Fail()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;

            // Act
            var result = myBackend.Read(null);

            // Reset

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Ensure the Read Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Photo_Read_Get_Data_InValid_Bogus_Should_Fail()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;

            // Act
            var result = myBackend.Read("bogus");

            // Reset

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Ensure the Read Method with empty string data should fail
        /// </summary>
        [TestMethod]
        public void Photo_Read_Get_Data_InValid_Empty_Should_Fail()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;

            // Act
            var result = myBackend.Read("");

            // Reset

            // Assert
            Assert.IsNull(result);
        }
        #endregion ReadTests

        #region UpdateTests
        /// <summary>
        /// Ensure the Update Method on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Photo_Update_Default_Should_Pass()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;
            var myData = myBackend.Index().FirstOrDefault();

            // Make a Copy of the Data and update an aspect of it
            var myDataCopy = new PhotoModel(myData);
            myDataCopy.ID = myData.ID; // Force the ID to match for this test.
            myDataCopy.Note = "New3";

            // Act
            var result = myBackend.Update(myDataCopy);

            // Reset
            myBackend.Reset();

            // Assert
            Assert.AreEqual("New3", result.Note);

        }

        /// <summary>
        /// Updating a Null record, shoudl Fail
        /// </summary>
        [TestMethod]
        public void Photo_Update_InValid_Null_Should_Fail()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;

            // Act
            var result = myBackend.Update(null);

            // Reset
            myBackend.Reset();

            // Assert
            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// Updating a bogus record, should Fail
        /// </summary>
        [TestMethod]
        public void Photo_Update_InValid_Bogus_Should_Fail()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;
            var myDataCopy = new PhotoModel
            {
                ID = "bogus"
            };

            // Act
            var result = myBackend.Update(myDataCopy);

            // Reset
            myBackend.Reset();

            // Assert
            Assert.AreEqual(null, result);
        }
        #endregion UpdateTests

        #region DeleteTests
        /// <summary>
        /// Ensure the Delete Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Photo_Delete_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;

            // Act
            var result = myBackend.Delete(null);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Ensure the Delete Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Photo_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;

            // Act
            var result = myBackend.Delete("bogus");

            // Reset

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
        public void Photo_Reset_Data_Valid_Should_Pass()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;
            var dataOriginal = myBackend.Index().FirstOrDefault();

            // Act
            myBackend.Delete(dataOriginal.ID);

            // Reset
            myBackend.Reset();

            // Assert
            Assert.AreEqual(dataOriginal.Note, myBackend.Index().FirstOrDefault().Note);
        }
        #endregion ResetTests

        #region BackupDataTests
        /// <summary>
        /// Call for a Backup, Mock ignores the call.
        /// </summary>
        [TestMethod]
        public void Photo_BackupData_Data_Valid_Should_Pass()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;

            // Act
            var result = myBackend.BackupData(DataSourceEnum.Local, DataSourceEnum.Local);

            // Reset

            // Assert
            Assert.IsTrue(result);
        }
        #endregion BackupDataTests

        #region Set_DataSetTests
        /// <summary>
        /// Call for The Demo Data Set
        /// Then reset to the Default
        /// Return True, because no different currently
        /// If different sets are implemented, then verify the sets
        /// </summary>
        [TestMethod]
        public void Photo_DataSetDemo_Data_Valid_Should_Pass()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;

            // Act
            myBackend.LoadDataSet(DataSourceDataSetEnum.Demo);

            // Reset
            myBackend.LoadDataSet(DataSourceDataSetEnum.Default);

            // Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Call for The Demo Data Unit Test Set
        /// Then reset to the Default
        /// Return True, because no different currently
        /// If different sets are implemented, then verify the sets
        /// </summary>
        [TestMethod]
        public void Photo_DataSetUnitTest_Data_Valid_Should_Pass()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;

            // Act
            myBackend.LoadDataSet(DataSourceDataSetEnum.UnitTest);

            // Reset
            myBackend.LoadDataSet(DataSourceDataSetEnum.Default);

            // Assert
            Assert.IsTrue(true);
        }
        #endregion Set_DataSetTests

        #region GetDataSourceStringTests
        /// <summary>
        /// String should Match the Mock or Store
        /// </summary>
        [TestMethod]
        public void Photo_GetDataSourceString_Data_Valid_Should_Pass()
        {
            // Arrange
            var myBackend = PhotoRepositoryMock.Instance;

            // Act
            var result = myBackend.GetDataSourceString();

            // Reset
            myBackend.LoadDataSet(DataSourceDataSetEnum.Default);

            // Assert
            Assert.AreEqual("Mock", result);
        }
        #endregion GetDataSourceStringTests
    }
}
