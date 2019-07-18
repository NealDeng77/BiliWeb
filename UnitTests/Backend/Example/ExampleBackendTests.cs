using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BiliWeb.Models;
using BiliWeb.Controllers;
using BiliWeb.Backend;

namespace UnitTests.Backend
{
    [TestClass]
    public class ExampleControlerTests
    {
        #region IndexTests
        /// <summary>
        /// Ensure the Default Index page on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Index_Get_Default_Should_Pass()
        {
            // Arrange
            var MyBackend = ExampleBackend.Instance;

            // Act
            var myTest = MyBackend.Index();

            // Reset


            // Assert
            Assert.IsNotNull(myTest);
        }
        #endregion IndexTests

        #region CreateTests
        /// <summary>
        /// Ensure the Create Method Post on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Create_Post_Default_Should_Pass()
        {
            // Arrange
            var MyBackend = ExampleBackend.Instance;
            var myData = new ExampleModel();

            // Act
            var myTest = MyBackend.Create(myData);

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
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
            var MyBackend = ExampleBackend.Instance;

            // Act
            var myTest = MyBackend.Read(null);

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
            var MyBackend = ExampleBackend.Instance;

            // Act
            var myTest = MyBackend.Read("bogus");

            // Reset

            // Assert
            Assert.IsNull(myTest);
        }
        #endregion ReadTests

        #region UpdateTests
        /// <summary>
        /// Ensure the Update Method Post on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Update_Post_Default_Should_Pass()
        {
            // Arrange
            var MyBackend = ExampleBackend.Instance;
            var myData = MyBackend.Index().FirstOrDefault();

            // Make a Copy of the Data and update an aspect of it
            var myTest = new ExampleModel(myData);
            myTest.ID = myData.ID; // Force the ID to match for this test.
            myTest.Name = "New";

            // Act
            MyBackend.Update(myTest);
            var result = MyBackend.Read(myData.ID);

            // Reset

            // Assert
            Assert.AreEqual("New",result.Name);
            
        }
        #endregion UpdateTests

        #region DeleteTests
        /// <summary>
        /// Ensure the Delete Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Example_Delete_Get_Data_Null_Should_Fail()
        {
            // Arrange
            var MyBackend = ExampleBackend.Instance;

            // Act
            var myTest = MyBackend.Delete(null);

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        /// <summary>
        /// Ensure the Delete Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Example_Delete_Get_Data_In_Valid_Should_Fail()
        {
            // Arrange
            var MyBackend = ExampleBackend.Instance;

            // Act
            var myTest = MyBackend.Delete("bogus");

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }
        #endregion DeleteTests
    }
}
