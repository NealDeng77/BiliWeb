using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Example
{
    [TestClass]
    public class ExampleDeleteViewTest
    {
        [TestMethod]
        public void Example_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var result = myController.Delete("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
