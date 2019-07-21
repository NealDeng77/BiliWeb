using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Phone
{
    [TestClass]
    public class PhoneDeleteViewTest
    {
        [TestMethod]
        public void Phone_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new PhoneController();

            // Act
            var myTest = myController.Delete("bogus");

            // Assert
            Assert.IsNotNull(myTest);
        }
    }
}
