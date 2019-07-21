using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Phone
{
    [TestClass]
    public class PhoneIndexViewTest
    {
        [TestMethod]
        public void Phone_Index_Default_Should_Pass()
        {
            // Arrange
            var myController = new PhoneController();

            // Act
            var myTest = myController.Index();

            // Assert
            Assert.IsNotNull(myTest);
        }
    }
}
