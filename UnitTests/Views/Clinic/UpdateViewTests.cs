using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Clinic
{
    [TestClass]
    public class ClinicViewTest
    {
        [TestMethod]
        public void Clinic_Update_Default_Should_Pass()
        {
            // Arrange
            var myController = new ClinicController();

            // Act
            var result = myController.Update("abc");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
