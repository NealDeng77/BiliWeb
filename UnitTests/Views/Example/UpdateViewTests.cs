using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views
{
    [TestClass]
    public class UpdateViewTest
    {
        [TestMethod]
        public void Example_Update_Default_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Update("abc");

            // Assert
            Assert.IsNotNull(myTest);
        }
    }
}
