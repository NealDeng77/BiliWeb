using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.VersionOS
{
    [TestClass]
    public class VersionOSCreateViewTests
    {
        [TestMethod]
        public void VersionOS_Create_Default_Should_Pass()
        {
            // Arrange
            var myController = new VersionOSController();

            // Act
            var result = myController.Create();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
