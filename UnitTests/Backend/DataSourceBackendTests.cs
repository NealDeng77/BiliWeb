using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BiliWeb.Models;
using BiliWeb.Controllers;
using BiliWeb.Backend;

namespace UnitTests.Backend
{
    [TestClass]
    public class DataSourceBackendTests
    {
        #region ResetTests
        /// <summary>
        /// Test Reset
        /// </summary>
        [TestMethod]
        public void DataSource_Reset_Should_Pass()
        {
            // Arrange
            var myBackend = DataSourceBackend.Instance;

            // Act
            myBackend.Reset();

            // Reset
            DataSourceBackend.Instance.Reset();

            // Assert
            Assert.IsTrue(true);
        }
        #endregion ResetTests

        #region GetTestingMode
        /// <summary>
        /// Test Reset
        /// </summary>
        [TestMethod]
        public void DataSource_GetTestingMode_Should_Pass()
        {
            // Arrange

            // Act
            var result = DataSourceBackend.GetTestingMode();

            // Reset

            // Assert
            Assert.AreEqual(false,result);
        }
        #endregion GetTestingMode

        #region SetTestingMode
        /// <summary>
        /// Set Testing Mode to True
        /// </summary>
        [TestMethod]
        public void DataSource_SetTestingMode_True_Should_Pass()
        {
            // Arrange
            var currentMode = DataSourceBackend.GetTestingMode();

            // Act
            DataSourceBackend.SetTestingMode(true);
            var newMode = DataSourceBackend.GetTestingMode();

            // Reset
            DataSourceBackend.SetTestingMode(currentMode);

            // Assert
            Assert.AreEqual(true, newMode);
        }

        /// <summary>
        /// Set Testing Mode to False
        /// </summary>
        [TestMethod]
        public void DataSource_SetTestingMode_False_Should_Pass()
        {
            // Arrange
            var currentMode = DataSourceBackend.GetTestingMode();

            // Act
            DataSourceBackend.SetTestingMode(false);
            var newMode = DataSourceBackend.GetTestingMode();

            // Reset
            DataSourceBackend.SetTestingMode(currentMode);

            // Assert
            Assert.AreEqual(false, newMode);
        }

        #endregion SetTestingMode

        #region SetDataSourceTests
        /// <summary>
        /// Test SetDataSource
        /// </summary>
        [TestMethod]
        public void DataSource_SetDataSource_Should_Pass()
        {
            // Arrange
            var myBackend = DataSourceBackend.Instance;

            // Act
            myBackend.SetDataSource(DataSourceEnum.Mock);

            // Assert
            Assert.IsTrue(true);
        }
        #endregion SetDataSourceTests

        #region SetDataSourceDataSetTests
        /// <summary>
        /// Test SetDataSourceDataSet
        /// </summary>
        [TestMethod]
        public void DataSource_SetDataSourceDataSet_Should_Pass()
        {
            // Arrange
            var myBackend = DataSourceBackend.Instance;

            // Act
            myBackend.SetDataSourceDataSet(DataSourceDataSetEnum.Default);

            // Assert
            Assert.IsTrue(true);
        }
        #endregion SetDataSourceDataSetTests

    }
}


        //SetDataSourceDataSet(DataSourceDataSetEnum SetEnum);
