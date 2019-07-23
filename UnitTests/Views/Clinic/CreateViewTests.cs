using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Clinic
{
    [TestClass]
    public class ClinicCreateViewTests
    {
        [TestMethod]
        public void Clinic_Create_Default_Should_Pass()
        {
            // Arrange
            var myController = new ClinicController();

            // Act
            var result = myController.Create();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
