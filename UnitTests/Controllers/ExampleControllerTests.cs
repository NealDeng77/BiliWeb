using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Controllers
{
    [TestClass]
    public class ExampleControlerTests
    {
        /// <summary>
        /// Ensure the Default Index page on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Default_Index_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Index();

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }
    }
}
