using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Clinic
{
    [TestClass]
    public class ClinicDeleteViewTest
    {
        [TestMethod]
        public void Clinic_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new ClinicController();

            // Act
            var result = myController.Delete("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
