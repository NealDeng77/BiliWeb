using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Phone
{
    [TestClass]
    public class PhoneViewTest
    {
        [TestMethod]
        public void Phone_Update_Default_Should_Pass()
        {
            // Arrange
            var myController = new PhoneController();

            // Act
            var myTest = myController.Update("abc");

            // Assert
            Assert.IsNotNull(myTest);
        }
    }
}
