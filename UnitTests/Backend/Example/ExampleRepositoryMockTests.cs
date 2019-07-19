using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BiliWeb.Models;
using BiliWeb.Controllers;
using BiliWeb.Backend;

namespace UnitTests.Backend
{
    [TestClass]
    public class ExampleRepositoryMockTests
    {
        #region IndexTests
        /// <summary>
        /// Ensure the Default Index page on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Index_Get_Default_Should_Pass()
        {
            // Arrange
            var myBackend = ExampleRepositoryMock.Instance;

            // Act
            var myTest = myBackend.Index();

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }
        #endregion IndexTests

        #region CreateTests
        /// <summary>
        /// Ensure the Create Method on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Create_Default_Should_Pass()
        {
            // Arrange
            var myBackend = ExampleRepositoryMock.Instance;
            var myData = new ExampleModel();

            // Act
            var myTest = myBackend.Create(myData);

            // Reset
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.IsNotNull(myTest);
        }

        /// <summary>
        /// Create with Null should Fail
        /// </summary>
        [TestMethod]
        public void Example_Create_InValid_Null_Should_Fail()
        {
            // Arrange
            var myBackend = ExampleRepositoryMock.Instance;
            var myData = new ExampleModel();

            // Act
            var myTest = myBackend.Create(null);

            // Reset
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.IsNull(myTest);
        }
        #endregion CreateTests

        #region ReadTests
        /// <summary>
        /// Ensure the Read Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Example_Read_Get_Data_InValid_Null_Should_Fail()
        {
            // Arrange
            var myBackend = ExampleRepositoryMock.Instance;

            // Act
            var myTest = myBackend.Read(null);

            // Reset

            // Assert
            Assert.IsNull(myTest);
        }

        /// <summary>
        /// Ensure the Read Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Example_Read_Get_Data_InValid_Bogus_Should_Fail()
        {
            // Arrange
            var myBackend = ExampleRepositoryMock.Instance;

            // Act
            var myTest = myBackend.Read("bogus");

            // Reset

            // Assert
            Assert.IsNull(myTest);
        }
        #endregion ReadTests

        #region UpdateTests
        /// <summary>
        /// Ensure the Update Method on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Update_Default_Should_Pass()
        {
            // Arrange
            var myBackend = ExampleRepositoryMock.Instance;
            var myData = myBackend.Index().FirstOrDefault();

            // Make a Copy of the Data and update an aspect of it
            var myTest = new ExampleModel(myData);
            myTest.ID = myData.ID; // Force the ID to match for this test.
            myTest.Name = "New3";

            // Act
            myBackend.Update(myTest);
            var result = myBackend.Read(myData.ID);

            // Reset
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual("New3",result.Name);
            
        }
        #endregion UpdateTests

        #region DeleteTests
        /// <summary>
        /// Ensure the Delete Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Example_Delete_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            var myBackend = ExampleRepositoryMock.Instance;

            // Act
            var myTest = myBackend.Delete(null);

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        /// <summary>
        /// Ensure the Delete Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Example_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myBackend = ExampleRepositoryMock.Instance;

            // Act
            var myTest = myBackend.Delete("bogus");

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
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
        public void Example_Reset_Data_Valid_Should_Pass()
        {
            // Arrange
            var myBackend = ExampleRepositoryMock.Instance;
            var dataOriginal = myBackend.Index().FirstOrDefault();

            // Act
            myBackend.Delete(dataOriginal.ID);

            // Reset
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual(dataOriginal.Name, myBackend.Index().FirstOrDefault().Name);
        }
        #endregion ResetTests

        #region BackupDataTests
        /// <summary>
        /// Call for a Backup, Mock ignores the call.
        /// </summary>
        [TestMethod]
        public void Example_BackupData_Data_Valid_Should_Pass()
        {
            // Arrange
            var myBackend = ExampleRepositoryMock.Instance;

            // Act
            var result = myBackend.BackupData(DataSourceEnum.Local, DataSourceEnum.Local);

            // Reset

            // Assert
            Assert.IsTrue(result);
        }
        #endregion BackupDataTests
    }
}
