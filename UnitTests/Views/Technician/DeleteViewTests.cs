using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Technician
{
    [TestClass]
    public class TechnicianDeleteViewTest
    {
        [TestMethod]
        public void Technician_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new TechnicianController();

            // Act
            var result = myController.Delete("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
