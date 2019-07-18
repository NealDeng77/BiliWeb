using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views
{
    [TestClass]
    public class ReadViewTest
    {
        [TestMethod]
        public void Example_Read_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Read("bogus");

            // Assert
            Assert.IsNotNull(myTest);
        }
    }
}
