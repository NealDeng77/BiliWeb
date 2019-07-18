using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views
{
    [TestClass]
    public class DeleteViewTest
    {
        [TestMethod]
        public void Example_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Delete("bogus");

            // Assert
            Assert.IsNotNull(myTest);
        }
    }
}
