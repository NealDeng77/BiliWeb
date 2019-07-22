using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Phone
{
    [TestClass]
    public class PhoneCreateViewTests
    {
        [TestMethod]
        public void Phone_Create_Default_Should_Pass()
        {
            // Arrange
            var myController = new PhoneController();

            // Act
            var result = myController.Create();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
