using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Clinic
{
    [TestClass]
    public class ClinicIndexViewTest
    {
        [TestMethod]
        public void Clinic_Index_Default_Should_Pass()
        {
            // Arrange
            var myController = new ClinicController();

            // Act
            var result = myController.Index();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
