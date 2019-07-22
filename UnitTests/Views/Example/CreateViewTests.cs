using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Example
{
    [TestClass]
    public class ExampleCreateViewTests
    {
        [TestMethod]
        public void Example_Create_Default_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var result = myController.Create();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
