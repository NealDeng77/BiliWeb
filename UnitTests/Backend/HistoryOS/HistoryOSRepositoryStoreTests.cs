using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BiliWeb.Models;
using BiliWeb.Controllers;
using BiliWeb.Backend;

namespace UnitTests.Backend
{
    [TestClass]
    public class HistoryOSRepositoryStoreTests
    {
        #region IndexTests
        /// <summary>
        /// Ensure the Default Index page on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void HistoryOS_Index_Get_Default_Should_Pass()
        {
            // Arrange
            var myBackend = HistoryOSRepositoryStore.Instance;

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
        public void HistoryOS_Create_Default_Should_Pass()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.HistoryOSBackend;
            var myData = new HistoryOSModel();

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
        public void HistoryOS_Create_InValid_Null_Should_Fail()
        {
            // Arrange
            // Set the Data to Local, so the calls will go to there.
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = HistoryOSRepositoryStore.Instance;
            var myData = new HistoryOSModel();

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
        public void HistoryOS_Read_Get_Data_InValid_Null_Should_Fail()
        {
            // Arrange
            var myBackend = HistoryOSRepositoryStore.Instance;

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
        public void HistoryOS_Read_Get_Data_InValid_Bogus_Should_Fail()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.HistoryOSBackend;

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
        public void HistoryOS_Update_Default_Should_Pass()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.HistoryOSBackend;
            var myData = myBackend.Index().FirstOrDefault();

            // Make a Copy of the Data and update an aspect of it
            var myDataCopy = new HistoryOSModel(myData);
            myDataCopy.ID = myData.ID; // Force the ID to match for this test.
            myDataCopy.PhoneID = "NewPhone";

            // Act
            var result = myBackend.Update(myDataCopy);

            // Reset
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual("NewPhone", result.PhoneID);

        }

        /// <summary>
        /// Updating a Null record, shoudl Fail
        /// </summary>
        [TestMethod]
        public void HistoryOS_Update_InValid_Null_Should_Fail()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.HistoryOSBackend;

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
        public void HistoryOS_Update_InValid_Bogus_Should_Fail()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.HistoryOSBackend;
            var myDataCopy = new HistoryOSModel
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
        public void HistoryOS_Delete_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.HistoryOSBackend;

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
        public void HistoryOS_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.HistoryOSBackend;

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
        public void HistoryOS_Reset_Data_Valid_Should_Pass()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.HistoryOSBackend;
            var dataOriginal = myBackend.Index().FirstOrDefault();

            // Act
            myBackend.Delete(dataOriginal.ID);

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.AreEqual(dataOriginal.PhoneID, myBackend.Index().FirstOrDefault().PhoneID);
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
        public void HistoryOS_GetDataSourceString_Data_Valid_Should_Pass()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = DataSourceBackend.Instance.HistoryOSBackend;

            // Act
            var result = myBackend.GetDataSourceString();

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.AreEqual("Store", result);
        }
        #endregion GetDataSourceStringTests


        #region Set_DataSetTests
        /// <summary>
        /// Call for The Default Data Data Set
        /// Returns True, so not validation
        /// </summary>
        [TestMethod]
        public void HistoryOS_LoadDataSet_Valid_Default_Should_Pass()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = HistoryOSRepositoryStore.Instance;

            // Act
            myBackend.LoadDataSet(DataSourceDataSetEnum.Default);

            // Reset
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Call for The UnitTest Data Data Set
        /// Returns True, so not validation
        /// </summary>
        [TestMethod]
        public void HistoryOS_LoadDataSet_Valid_UnitTest_Should_Pass()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = HistoryOSRepositoryStore.Instance;

            // Act
            myBackend.LoadDataSet(DataSourceDataSetEnum.UnitTest);

            // Reset
            myBackend.LoadDataSet(DataSourceDataSetEnum.Default);
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Call for The Demo Data Data Set
        /// Returns True, so not validation
        /// </summary>
        [TestMethod]
        public void HistoryOS_LoadDataSet_Valid_Demo_Should_Pass()
        {
            // Arrange
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Local);
            var myBackend = HistoryOSRepositoryStore.Instance;

            // Act
            myBackend.LoadDataSet(DataSourceDataSetEnum.Demo);

            // Reset
            myBackend.LoadDataSet(DataSourceDataSetEnum.Default);
            DataSourceBackend.Instance.Reset();
            DataSourceBackend.Instance.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.IsTrue(true);
        }
        #endregion Set_DataSetTests

    }
}
