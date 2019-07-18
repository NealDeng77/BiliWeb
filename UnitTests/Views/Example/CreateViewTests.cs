using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views
{
    [TestClass]
    public class CreateViewTests
    {
        [TestMethod]
        public void Example_Create_Default_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Create();

            // Assert
            Assert.IsNotNull(myTest);
        }
    }
}
