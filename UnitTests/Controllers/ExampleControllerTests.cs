using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Controllers
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
            var myController = new ExampleController();

            // Act
            var myTest = myController.Index();

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
        public void Example_Create_Get_Default_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Create();

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        /// <summary>
        /// Ensure the Create Method Post on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Create_Post_Default_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();
            var myData = new ExampleModel();

            // Act
            var myTest = myController.Create(myData);

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
        public void Example_Read_Get_Data_Null_Should_Fail()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Read(null);

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        /// <summary>
        /// Ensure the Read Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Example_Read_Get_Data_In_Valid_Should_Fail()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Read("bogus");

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }
        #endregion ReadTests

        #region UpdateTests
        /// <summary>
        /// Ensure the Update Method on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Update_Get_Default_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Update();

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        /// <summary>
        /// Ensure the Update Method Post on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Update_Post_Default_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();
            var myData = new ExampleModel();

            // Act
            var myTest = myController.Update(myData);

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
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
            var myController = new ExampleController();

            // Act
            var myTest = myController.Delete(null);

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
            var myController = new ExampleController();

            // Act
            var myTest = myController.Delete("bogus");

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }
        #endregion DeleteTests
    }
}
