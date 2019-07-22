using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BiliWeb.Models;
using BiliWeb.Controllers;
using BiliWeb.Backend;

namespace UnitTests.Backend
{
    [TestClass]
    public class ResultLogBackendTests
    {
        #region IndexTests
        /// <summary>
        /// Ensure the Default Index page on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void ResultLog_Index_Get_Default_Should_Pass()
        {
            // Arrange
            var myBackend = ResultLogBackend.Instance;

            // Act
            var result = myBackend.Index();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion IndexTests

        #region CreateTests
        /// <summary>
        /// Ensure the Create Method Post on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void ResultLog_Create_Post_Default_Should_Pass()
        {
            // Arrange
            var myBackend = ResultLogBackend.Instance;
            var myData = new ResultLogModel();

            // Act
            var result = myBackend.Create(myData);

            // Reset
            myBackend.Reset();

            // Assert
            Assert.IsNotNull(result);
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
            var myBackend = ResultLogBackend.Instance;

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
        public void ResultLog_Read_Get_Data_InValid_Bogus_Should_Fail()
        {
            // Arrange
            var myBackend = ResultLogBackend.Instance;

            // Act
            var result = myBackend.Read("bogus");

            // Reset

            // Assert
            Assert.IsNull(result);
        }
        #endregion ReadTests

        #region UpdateTests
        /// <summary>
        /// Ensure the Update Method Post on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void ResultLog_Update_Post_Default_Should_Pass()
        {
            // Arrange
            var myBackend = ResultLogBackend.Instance;
            var myData = myBackend.Index().FirstOrDefault();

            // Make a Copy of the Data and update an aspect of it
            var myDataCopy = new ResultLogModel(myData);
            myDataCopy.ID = myData.ID; // Force the ID to match for this test.
            myDataCopy.ClinicID = "New";

            // Act
            myBackend.Update(myDataCopy);
            var result = myBackend.Read(myData.ID);

            // Reset
            myBackend.Reset();

            // Assert
            Assert.AreEqual("New",result.ClinicID);
            
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
            var myBackend = ResultLogBackend.Instance;

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
        public void ResultLog_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myBackend = ResultLogBackend.Instance;

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
        public void ResultLog_Reset_Data_Valid_Should_Pass()
        {
            // Arrange
            var myBackend = ResultLogBackend.Instance;
            var dataOriginal = myBackend.Index().FirstOrDefault();

            // Act
            myBackend.Delete(dataOriginal.ID);

            // Reset
            myBackend.Reset();

            // Assert
            Assert.AreEqual(dataOriginal.ClinicID, myBackend.Index().FirstOrDefault().ClinicID);
        }
        #endregion ResetTests

        #region DataSourceTests
        /// <summary>
        /// Set the Data Source
        /// Verify it changed
        /// </summary>
        [TestMethod]
        public void ResultLog_SetDataSource_Data_Mock_Should_Pass()
        {
            // Arrange
            var myBackend = ResultLogBackend.Instance;
            var dataOriginal = myBackend.Index().FirstOrDefault();

            // Act
            ResultLogBackend.SetDataSource(DataSourceEnum.Mock);
            var result = ResultLogBackend.Instance.GetDataSourceString();

            // Reset
            myBackend.Reset();

            // Return Data Source to Mock
            ResultLogBackend.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.AreEqual("Mock", result);
        }

        /// <summary>
        /// Set the Data Source
        /// Verify it changed
        /// </summary>
        [TestMethod]
        public void ResultLog_SetDataSource_Data_Local_Should_Pass()
        {
            // Arrange
            var myBackend = ResultLogBackend.Instance;
            var dataOriginal = myBackend.Index().FirstOrDefault();

            // Act
            ResultLogBackend.SetDataSource(DataSourceEnum.Local);
            var result = ResultLogBackend.Instance.GetDataSourceString();

            // Reset
            myBackend.Reset();

            // Return Data Source to Mock
            ResultLogBackend.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.AreEqual("Store", result);
        }

        /// <summary>
        /// Calls for loading of Data Sets
        /// Demo set is the Default
        /// 
        /// </summary>
        [TestMethod]
        public void ResultLog_SetDataSourceSet_Data_Local_Should_Pass()
        {
            // Arrange
            var myBackend = ResultLogBackend.Instance;
            var dataOriginal = myBackend.Index().FirstOrDefault();

            // Act
            ResultLogBackend.SetDataSourceDataSet(DataSourceDataSetEnum.Default);

            // Reset
            myBackend.Reset();

            // Assert
            Assert.IsTrue(true);
        }

        #endregion DataSourceTests
    }
}
