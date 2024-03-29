using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Example
{
    [TestClass]
    public class ExampleIndexViewTest
    {
        [TestMethod]
        public void Example_Index_Default_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var result = myController.Index();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
