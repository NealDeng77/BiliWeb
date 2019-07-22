using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Technician
{
    [TestClass]
    public class TechnicianCreateViewTests
    {
        [TestMethod]
        public void Technician_Create_Default_Should_Pass()
        {
            // Arrange
            var myController = new TechnicianController();

            // Act
            var result = myController.Create();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
