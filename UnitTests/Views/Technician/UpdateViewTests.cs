using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Technician
{
    [TestClass]
    public class TechnicianViewTest
    {
        [TestMethod]
        public void Technician_Update_Default_Should_Pass()
        {
            // Arrange
            var myController = new TechnicianController();

            // Act
            var result = myController.Update("abc");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
