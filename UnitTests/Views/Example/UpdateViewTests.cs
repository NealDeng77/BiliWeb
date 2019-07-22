using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Example
{
    [TestClass]
    public class ExampleViewTest
    {
        [TestMethod]
        public void Example_Update_Default_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var result = myController.Update("abc");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
